using BL.Flows.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BL.Flows.Client
{

    public static class FlowClient
    {
        private static IMongoDatabase _db;
        private static IMongoCollection<Flow> _flows;
        //private static IMongoCollection<FlowBusiness> _flowBusinesses;
        private static IMongoCollection<FlowDef> _flowDefs;
        private static IMongoCollection<FlowRole> _flowRoles;
        private static IMongoCollection<FlowUserManageDept> _flowUserManageDepts;
        private static FlowMsgApiSetting _FlowMsgApiSetting;
        public static void Init(IMongoDatabase database, bool useDefalutdb = true, FlowMsgApiSetting flowMsgApiSetting = null)
        {
            _db = useDefalutdb ? database.Client.GetDatabase("blcommon") : database;
            _flows = _db.GetCollection<Flow>(CollNames.Flow);
            //_flowBusinesses = _db.GetCollection<FlowBusiness>(CollNames.FlowBusiness);
            _flowDefs = _db.GetCollection<FlowDef>(CollNames.FlowDef);
            _flowRoles = _db.GetCollection<FlowRole>(CollNames.FlowRole);
            _flowUserManageDepts = _db.GetCollection<FlowUserManageDept>(CollNames.FlowUserManageDept);
            _FlowMsgApiSetting = flowMsgApiSetting;
        }

        public static FlowNextResult Create(IClientSessionHandle session, FlowPostParam param)
        {
            param.Creator.Validate();
            //
            var flowDef = _flowDefs.Find(session, x => x.Id == param.FlowDef).SingleOrDefault() ?? throw new("flowDef is null"); ;
            //
            var obj = new Flow
            {
                Id = param.BusinessKeyId,
                Business = flowDef.BusinessType,
                BusinessKeyId = param.BusinessKeyId,
                DealStatus = false,
                Status = new(),
                CommonInfo = new()
                {
                    Title = param.Title,
                    FlowDef = new()
                    {
                        Rid = flowDef.Id,
                        Name = flowDef.Name,
                        ApproveType = flowDef.ApproveType
                    },
                    Creator = param.Creator
                },
                BusinessContents = param.BusinessContents,
                School = param.School
            };
            obj.BuildText();
            obj.Process = new()
            {
                Operators = new(),
                OperatorsNow = new(),
                StepNow = 1,
                Steps = flowDef.Steps.Select(x => new FlowStep
                {
                    No = x.No,
                    Role = x.Role,
                    StartTime = x.No == 1 ? DateTime.Now : null
                }).ToList()
            };
            if (obj.Process.Steps.Count == 0) throw new("process.steps of this flow is empty");
            //get next operate users
            var role = _flowRoles.Find(session, x => x.Id == obj.Process.Steps.First().Role.Rid).Project(x => new FlowNextResultRole(x.IsApplyerDept, x.Users)).SingleOrDefault() ?? throw new("the first step's role of this flow can not find in flowRoles");
            return new(obj, role);
        }

        public static void DynamicCreate(IClientSessionHandle session, FlowDynamicPostParam param)
        {
            param.Creator.Validate();
            if (param.Operators is null || param.Operators.Count == 0) throw new Exception("next operators can not be empty");
            //
            var flowDef = _flowDefs.Find(session, x => x.Id == param.FlowDef).SingleOrDefault() ?? throw new Exception("flowDef is null");
            if (flowDef.ApproveType != ApproveType.Danymic) throw new Exception("flowDef approve must be dynamic");
            //
            var obj = new Flow
            {
                Id = param.BusinessKeyId,
                Business = flowDef.BusinessType,
                BusinessKeyId = param.BusinessKeyId,
                DealStatus = false,
                Status = new FlowStatus(),
                CommonInfo = new FlowCommonInfo
                {
                    Title = param.Title,
                    FlowDef = new FlowDefReference
                    {
                        Rid = flowDef.Id,
                        Name = flowDef.Name,
                        ApproveType = flowDef.ApproveType
                    },
                    Creator = param.Creator
                },
                BusinessContents = param.BusinessContents,
                School = param.School
            };
            obj.BuildText();
            obj.Process = new FlowProcess
            {
                Operators = new List<FlowReferenceItem>(),
                OperatorsNow = param.Operators,
                StepNow = 1,
                Steps = new List<FlowStep> { }
            };
            _ = _flows.ReplaceOne(session, x => x.Id == obj.Id, obj, new ReplaceOptions { IsUpsert = true });
        }
        public static void DynamicApprove(IClientSessionHandle session, string user, string id, string comment)
        {
            var flow = _flows.Find(session, x => x.Id == id).SingleOrDefault() ?? throw new Exception("no data find");
            if (flow.CommonInfo.FlowDef.ApproveType != ApproveType.Danymic) throw new Exception("this method only use for dynamic approve type");
            if (flow.Status.Pass != FlowStatusPass.审批中) throw new Exception("该流程已结束");
            var operatorNow = flow.Process.OperatorsNow.Find(x => x.Rid == user) ?? throw new Exception("当前操作人非此步骤人员");
            var step = new FlowStep
            {
                No = flow.Process.Steps.Count + 1,
                Agree = true,
                Comment = comment,
                OperateTime = DateTime.Now,
                Operator = operatorNow
            };
            flow.Process.Steps.Add(step);
            flow.Process.Operators.Add(operatorNow);
            var creator = flow.CommonInfo.Creator;
            flow.Process.OperatorsNow.Clear();
            flow.Process.OperatorsNow.Add(new FlowReferenceItem(creator.Rid, creator.Name));
            _ = _flows.ReplaceOne(session, x => x.Id == flow.Id, flow, new ReplaceOptions { IsUpsert = true });
        }
        public static void DynamicNext(IClientSessionHandle session, string user, string id, List<FlowReferenceItem> operators = null)
        {
            var flow = _flows.Find(session, x => x.Id == id).SingleOrDefault() ?? throw new Exception("no data find");
            if (flow.CommonInfo.FlowDef.ApproveType != ApproveType.Danymic) throw new Exception("this method only use for dynamic approve type");
            if (flow.Status.Pass != FlowStatusPass.审批中) throw new Exception("该流程已结束");
            var operatorNow = flow.Process.OperatorsNow.Find(x => x.Rid == user) ?? throw new Exception("当前操作人非此步骤人员");
            if (operators is null || operators.Count == 0)
            {
                flow.Status = new FlowStatus { OverTime = DateTime.Now, Pass = FlowStatusPass.已通过 };
            }
            else
            {
                flow.Process.Operators.Add(operatorNow);
                flow.Process.OperatorsNow.Clear();
                flow.Process.OperatorsNow.AddRange(operators.Select(x => new FlowReferenceItem(x.Rid, x.Name)));
            }
            _ = _flows.ReplaceOne(session, x => x.Id == flow.Id, flow, new ReplaceOptions { IsUpsert = true });
        }

        public static FlowsNextResult CreateBatch(IClientSessionHandle session, FlowPostParamBatch param)
        {
            foreach (var item in param.Creators) item.Validate();
            //
            var flowDef = _flowDefs.Find(session, x => x.Id == param.FlowDef).SingleOrDefault() ?? throw new("flowDef is null");
            //
            var objs = param.Creators.Select(x => new Flow
            {
                Business = flowDef.BusinessType,
                DealStatus = false,
                Status = new(),
                CommonInfo = new() { Title = param.Title, FlowDef = new() { Rid = flowDef.Id, Name = flowDef.Name, ApproveType = flowDef.ApproveType }, Creator = x },
                BusinessContents = param.BusinessContents,
                School = param.School
            }).ToList();
            for (int i = 0; i < objs.Count; i++)
            {
                var item = objs[i];
                item.Id = param.BusinessKeyIds[i];
                item.BusinessKeyId = item.Id;
                item.BuildText();
                item.Process = new()
                {
                    Operators = new(),
                    OperatorsNow = new(),
                    StepNow = 1,
                    Steps = flowDef.Steps.Select(x => new FlowStep { No = x.No, Role = x.Role, StartTime = x.No == 1 ? DateTime.Now : null }).ToList()
                };
                if (item.Process.Steps.Count == 0) throw new("process.steps of this flow is empty");
            }
            //get next operate users
            var roleid = objs[0].Process.Steps.First().Role.Rid;
            var role = _flowRoles.Find(session, x => x.Id == roleid).Project(x => new FlowNextResultRole(x.IsApplyerDept, x.Users)).SingleOrDefault() ?? throw new("the first step's role of this flow can not find in flowRoles");
            return new(objs, role);
        }

        public static FlowApproveResult Approve(IClientSessionHandle session, string user, string id, bool agree, string comment)
        {
            var flow = _flows.Find(session, x => x.Id == id).SingleOrDefault() ?? throw new("no data find");
            if (flow.Status.Pass != FlowStatusPass.审批中) throw new("该流程已结束");
            var operatorNow = flow.Process.OperatorsNow.Find(x => x.Rid == user) ?? throw new("当前操作人非此步骤人员");
            var process = flow.Process;
            var roles = _flowRoles.Find(session, x => x.School == flow.School && x.Users.Any(u => u.Rid == user)).Project(x => new FlowReferenceItem(x.Id, x.Name)).ToList();
            if (flow.CommonInfo.FlowDef.ApproveType == ApproveType.Or)//或签直接结束
            {
                var step = flow.Process.Steps.Find(x => x.Agree is null && roles.Any(r => r.Rid == x.Role.Rid)) ?? throw new("未找到匹配的待处理步骤或此用户非待处理步骤角色");
                step.Operator = operatorNow;
                step.OperateTime = DateTime.Now;
                step.Agree = agree;
                step.Comment = comment;
                //
                process.OperatorsNow = new(); //清空当前操作人
                flow.Status.Pass = agree ? FlowStatusPass.已通过 : FlowStatusPass.未通过;
                flow.Status.OverTime = DateTime.Now;
                //
                process.Operators.Add(operatorNow);
                return new(flow, null, agree ? "审批通过" : "审批拒绝");
            }
            else if (flow.CommonInfo.FlowDef.ApproveType == ApproveType.All)//会签找到当前操作人所有相关步骤,全部处理
            {
                var steps = flow.Process.Steps.FindAll(x => x.Agree is null && roles.Any(r => r.Rid == x.Role.Rid));
                if (steps.Count == 0) throw new("未找到匹配的待处理步骤或此用户非待处理步骤角色");
                foreach (var step in steps)
                {
                    step.Operator = operatorNow;
                    step.OperateTime = DateTime.Now;
                    step.Agree = agree;
                    step.Comment = comment;
                }
                if (agree == false || process.Steps.Any(x => x.Agree == null) == false) //1.拒绝则流程结束 2.同意并且所有人均已操作则结束
                {
                    process.OperatorsNow = new(); //清空当前操作人
                    flow.Status.Pass = agree ? FlowStatusPass.已通过 : FlowStatusPass.未通过;
                    flow.Status.OverTime = DateTime.Now;
                }
                else
                {
                    _ = process.OperatorsNow.RemoveAll(x => x.Rid == user); //移除当前操作人
                }
                //
                process.Operators.Add(operatorNow);
                return new(flow, null, flow.Status.Pass == FlowStatusPass.已通过 ? "审批通过" : agree ? "审批同意" : "审批拒绝");
            }
            else if (flow.CommonInfo.FlowDef.ApproveType == ApproveType.Continuous)
            {
                var step = process.Steps.First(x => x.Agree is null);
                if (step.No != process.StepNow) throw new("error,process.stepNow is not eq to first null operate step");
                if (roles.Any(x => x.Rid == step.Role.Rid) == false) throw new($"该待处理步骤需要角色[{step.Role.Name}],但该用户无此角色");
                step.Agree = agree;
                step.Operator = operatorNow;
                step.OperateTime = DateTime.Now;
                step.Comment = comment;
                process.OperatorsNow = new(); //清空当前操作人
                process.Operators.Add(operatorNow);//添加历史操作人
                if (agree == false || process.Steps.Any(x => x.Agree == null) == false)//流程结束
                {
                    flow.Status.Pass = agree ? FlowStatusPass.已通过 : FlowStatusPass.未通过;
                    flow.Status.OverTime = DateTime.Now;
                    return new(flow, null, agree ? "审批通过" : "审批拒绝");
                }
                else
                {
                    var stepNext = process.Steps.First(x => x.Agree is null);
                    stepNext.StartTime = DateTime.Now;
                    process.StepNow += 1;
                    //get next operate users
                    var role = _flowRoles.Find(session, x => x.Id == stepNext.Role.Rid).Project(x => new FlowNextResultRole(x.IsApplyerDept, x.Users)).SingleOrDefault() ?? throw new("the first step's role of this flow can not find in flowRoles");
                    return new(flow, role, "审批同意");
                }
            }
            else if (flow.CommonInfo.FlowDef.ApproveType == ApproveType.Danymic) throw new("please use specific method for Danymic Flow");
            else throw new("approveType error");
        }

        public static void NextOperatorsFill(IClientSessionHandle session, FlowNextResult flowNextResult, IEnumerable<string> nextURids = null, bool deptManageFilter = true)
        {
            var role = flowNextResult.Role;
            var flow = flowNextResult.Flow;
            if (nextURids?.Count() > 0)
            {
                _ = role.Users.RemoveAll(x => nextURids.Contains(x.Rid) == false);
            }
            if (!role.IsApplyerDept && deptManageFilter)
            {
                if (flow.CommonInfo.Creator.Org?.Rid is not null)
                {
                    var manageURids = _flowUserManageDepts.Find(session, x => x.School == flow.School && nextURids.Contains(x.User.Rid) && x.Departments.Any(d => d.Rid == flow.CommonInfo.Creator.Org.Rid)).Project(x => x.User.Rid).ToList();
                    if (manageURids.Count > 0) _ = role.Users.RemoveAll(x => manageURids.Contains(x.Rid) == false);
                }
            }
            flow.Process.OperatorsNow = role.Users;
        }
        public static void NextOperatorsFill(IClientSessionHandle session, FlowsNextResult fnr, IEnumerable<string> nextURids = null, bool deptManageFilter = true)
        {
            var role = fnr.Role;
            var flows = fnr.Flows;
            if (nextURids?.Count() > 0)
            {
                _ = role.Users.RemoveAll(x => nextURids.Contains(x.Rid) == false);
            }
            if (!role.IsApplyerDept && deptManageFilter)
            {
                if (flows.First().CommonInfo.Creator.Org?.Rid is not null)
                {
                    var manageURids = _flowUserManageDepts.Find(session, x => x.School == flows.First().School && nextURids.Contains(x.User.Rid) && x.Departments.Any(d => d.Rid == flows.First().CommonInfo.Creator.Org.Rid)).Project(x => x.User.Rid).ToList();
                    if (manageURids.Count > 0) _ = role.Users.RemoveAll(x => manageURids.Contains(x.Rid) == false);
                }
            }
            foreach (var item in flows) item.Process.OperatorsNow = role.Users;
        }

        public static void Update(IClientSessionHandle session, Flow flow)
        {
            _ = _flows.ReplaceOne(session, x => x.Id == flow.Id, flow, new ReplaceOptions { IsUpsert = true });
            CreateNotices(flow);
        }
        public static void Update(IClientSessionHandle session, IEnumerable<Flow> flows)
        {
            IEnumerable<ReplaceOneModel<Flow>> writes = flows.Select(x => new ReplaceOneModel<Flow>(Builders<Flow>.Filter.Eq(y => y.Id, x.Id), x) { IsUpsert = true });
            _ = _flows.BulkWrite(session, writes, new BulkWriteOptions { IsOrdered = false });
            foreach (var flow in flows) CreateNotices(flow);
        }
        private static void CreateNotices(Flow flow)
        {
            if (flow.Status.Pass == FlowStatusPass.审批中)
            {
                if (flow.Process.StepNow > 1)//when flow first commit,stepnow is 1,do not need to notify appler. stepnow>1 is approver agree
                {
                    if (_FlowMsgApiSetting?.NotifyAppler is not null)
                    {
                        var step = flow.Process.Steps.Last(x => x.Agree is not null);
                        _ = CreateNotifyApplyerMessage(new()
                        {
                            Business = flow.Business,
                            BusinessKeyId = flow.BusinessKeyId,
                            Title = flow.CommonInfo.Title,
                            Applyer = new(flow.CommonInfo.Creator.Rid, flow.CommonInfo.Creator.Name),
                            Approver = step.Operator,
                            Agree = (bool)step.Agree,
                            Comment = step.Comment,
                            OperateTime = (DateTime)step.OperateTime,
                            FlowStatusPass = flow.Status.Pass,
                            School = flow.School
                        });
                    }
                }
                if (_FlowMsgApiSetting?.NotifyApprover is not null)
                {
                    if (flow.Process.OperatorsNow.Count > 0)
                    {
                        _ = CreateNotifyApproverMessage(new()
                        {
                            Business = flow.Business,
                            Title = flow.CommonInfo.Title,
                            BusinessKeyId = flow.BusinessKeyId,
                            Users = flow.Process.OperatorsNow,
                            School = flow.School
                        });
                    }
                }
            }
            else if (flow.Status.Pass is FlowStatusPass.已通过 or FlowStatusPass.未通过)
            {
                if (_FlowMsgApiSetting?.NotifyAppler is not null)
                {
                    var step = flow.Process.Steps.Last(x => x.Agree is not null);
                    _ = CreateNotifyApplyerMessage(new()
                    {
                        Business = flow.Business,
                        BusinessKeyId = flow.BusinessKeyId,
                        Title = flow.CommonInfo.Title,
                        Applyer = new(flow.CommonInfo.Creator.Rid, flow.CommonInfo.Creator.Name),
                        Approver = step.Operator,
                        Agree = (bool)step.Agree,
                        Comment = step.Comment,
                        OperateTime = (DateTime)step.OperateTime,
                        FlowStatusPass = flow.Status.Pass,
                        School = flow.School
                    });
                }
            }
        }
        private static async Task CreateNotifyApproverMessage(FlowApproverMsgDto dto)
        {
            try
            {
                var jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                var parm = JsonSerializer.Serialize(dto, jsonSerializerOptions);
                var postcontent = new StringContent(parm, Encoding.UTF8, "application/json");
                var httpClient = new HttpClient { };
                var syncrs = await httpClient.PostAsync(_FlowMsgApiSetting.NotifyApprover, postcontent);
                if (!syncrs.IsSuccessStatusCode)
                {
                    Console.WriteLine($"error to send msg to flow approvers,reason:{syncrs.StatusCode}:{syncrs.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"消息推送失败:{ex}");
            }
        }
        private static async Task CreateNotifyApplyerMessage(FlowApplyerMsgDto dto)
        {
            try
            {
                var jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                var parm = JsonSerializer.Serialize(dto, jsonSerializerOptions);
                var postcontent = new StringContent(parm, Encoding.UTF8, "application/json");
                var httpClient = new HttpClient { };
                var syncrs = await httpClient.PostAsync(_FlowMsgApiSetting.NotifyAppler, postcontent);
                if (!syncrs.IsSuccessStatusCode)
                {
                    Console.WriteLine($"error to send msg to flow applyer,reason:{syncrs.StatusCode}:{syncrs.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"消息推送失败:{ex}");
            }
        }



    }

    public class FlowMsgApiSetting
    {
        public string NotifyApprover { get; set; }
        public string NotifyAppler { get; set; }
    }
    public class FlowApproverMsgDto
    {
        public string BusinessKeyId { get; set; }
        public FlowBusiness Business { get; set; }
        public string Title { get; set; }
        public List<FlowReferenceItem> Users { get; set; }
        public string School { get; set; }
    }
    public class FlowApplyerMsgDto
    {
        public string BusinessKeyId { get; set; }
        public FlowBusiness Business { get; set; }
        public string Title { get; set; }
        public FlowReferenceItem Applyer { get; set; }
        public FlowReferenceItem Approver { get; set; }
        public bool Agree { get; set; }
        public string Comment { get; set; }
        public DateTime OperateTime { get; set; }
        public FlowStatusPass FlowStatusPass { get; set; }
        public string School { get; set; }
    }

    #region dto_post
    public class FlowPostParamBase
    {
        [Required]
        public string School { get; set; }
        [Required]
        public string FlowDef { get; set; }
        [Required]
        public string Title { get; set; }
        public List<FlowBusinessContentsItem> BusinessContents { get; set; }
    }
    public class FlowDynamicPostParam : FlowPostParam
    {
        public List<FlowReferenceItem> Operators { get; set; }
    }
    public class FlowPostParam : FlowPostParamBase
    {
        [Required]
        public string BusinessKeyId { get; set; }
        [Required]
        public FlowCreator Creator { get; set; }
    }
    public class FlowPostParamBatch : FlowPostParamBase
    {
        [Required]
        public List<string> BusinessKeyIds { get; set; }
        [Required]
        public List<FlowCreator> Creators { get; set; }
    }


    public class FlowsNextResult
    {
        public FlowsNextResult(List<Flow> flows, FlowNextResultRole role)
        {
            Flows = flows;
            Role = role;
        }
        public List<Flow> Flows { get; }
        public FlowNextResultRole Role { get; }
        public IEnumerable<string> URids { get { return Role?.Users.Select(x => x.Rid); } }
        public void ReFillNextOperators(params FlowReferenceItem[] users)
        {
            Role.ReFillNextOperators(users);
        }
    }
    public class FlowApproveResult : FlowNextResult
    {
        public FlowApproveResult(Flow flow, FlowNextResultRole role, string operateTitle) : base(flow, role)
        {
            OperateTitle = operateTitle;
        }
        /// <summary>
        /// 审批通过,审批拒绝,审批同意
        /// </summary>
        public string OperateTitle { get; private set; }
    }
    public class FlowNextResult
    {
        public FlowNextResult(Flow flow, FlowNextResultRole role)
        {
            Flow = flow;
            Role = role;
        }
        public Flow Flow { get; }
        public FlowNextResultRole Role { get; }
        public IEnumerable<string> URids { get { return Role?.Users.Select(x => x.Rid); } }
        public void ReFillNextOperators(params FlowReferenceItem[] users)
        {
            Role.ReFillNextOperators(users);
        }
    }

    public class FlowNextResultRole
    {
        public bool IsApplyerDept { get; }
        public List<FlowReferenceItem> Users { get; }

        public FlowNextResultRole(bool isApplyerDept, List<FlowReferenceItem> users)
        {
            IsApplyerDept = isApplyerDept;
            Users = users;
        }
        public void ReFillNextOperators(params FlowReferenceItem[] users)
        {
            Users.Clear();
            Users.AddRange(users);
        }
    }

    #endregion dto_post
}
