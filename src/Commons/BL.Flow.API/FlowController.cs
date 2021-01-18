using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BL.Flows.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BL.Flows.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlowController : ControllerBase
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<Flow> coll;
        private readonly IMongoCollection<FlowBusiness> _flowBusinesses;
        private readonly IMongoCollection<FlowDef> _flowDefs;
        private readonly IMongoCollection<FlowRole> _flowRoles;
        private readonly IMongoCollection<FlowUserManageDept> _flowUserManageDepts;

        public FlowController(IMongoDatabase db)
        {
            this.db = db;
            coll = db.GetCollection<Flow>(CollNames.Flow);
            _flowBusinesses = db.GetCollection<FlowBusiness>(CollNames.FlowBusiness);
            _flowDefs = db.GetCollection<FlowDef>(CollNames.FlowDef);
            _flowRoles = db.GetCollection<FlowRole>(CollNames.FlowRole);
            _flowUserManageDepts = db.GetCollection<FlowUserManageDept>(CollNames.FlowUserManageDept);
        }

        private readonly FilterDefinitionBuilder<Flow> bf = Builders<Flow>.Filter;
        private readonly UpdateDefinitionBuilder<Flow> bu = Builders<Flow>.Update;

        [HttpPost("ForInnerUsing")]
        public (Flow, NextRoleResult) Post(IClientSessionHandle session, FlowPostParam param)
        {
            param.Creator.Validate();
            //
            var flowDef = _flowDefs.Find(session, x => x.Id == param.FlowDef).SingleOrDefault() ?? throw new Exception("flowDef is null"); ;
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
                //BusinessContents = dto.BusinessContents,
                School = param.School
            };
            obj.BuildText();
            obj.Process = new FlowProcess
            {
                Operators = new List<FlowReferenceItem>(),
                OperatorsNow = new List<FlowReferenceItem>(),
                StepNow = 1,
                Steps = flowDef.Steps.Select(x => new FlowStep
                {
                    No = x.No,
                    Role = x.Role,
                    StartTime = x.No == 1 ? (DateTime?)DateTime.Now : null
                }).ToList()
            };
            if (obj.Process.Steps.Count == 0) throw new Exception("process.steps of this flow is empty");
            //
            coll.InsertOne(obj);
            //get next operate users
            var role = _flowRoles.Find(session, x => x.Id == obj.Process.Steps.First().Role.Rid).Project(x => new NextRoleResult(x.IsApplyerDept, x.Users)).SingleOrDefault() ?? throw new Exception("the first step's role of this flow can not find in flowRoles");
            return (obj, role);
        }

        [HttpPost("ForInnerUsing/Approve")]
        public (Flow, NextRoleResult) ApprovePut(IClientSessionHandle session, string user, string id, bool agree, string comment)
        {
            var flow = coll.Find(session, x => x.Id == id).SingleOrDefault() ?? throw new Exception("no data find");
            if (flow.Status.Pass != FlowStatusPass.审批中) throw new Exception("该流程已结束");
            var operatorNow = flow.Process.OperatorsNow.Find(x => x.Rid == user) ?? throw new Exception("不在该步骤待操作用户列表中");
            var process = flow.Process;
            var roles = _flowRoles.Find(session, x => x.School == flow.School && x.Users.Any(u => u.Rid == user)).Project(x => new FlowReferenceItem(x.Id, x.Name)).ToList();
            if (flow.CommonInfo.FlowDef.ApproveType == ApproveType.Or)//或签直接结束
            {
                var step = flow.Process.Steps.Find(x => x.Agree is null && roles.Any(r => r.Rid == x.Role.Rid)) ?? throw new Exception("未找到匹配的待处理步骤或此用户非待处理步骤角色");
                step.Operator = operatorNow;
                step.OperateTime = DateTime.Now;
                step.Agree = agree;
                step.Comment = comment;
                //
                process.OperatorsNow = new List<FlowReferenceItem>(); //清空当前操作人
                flow.Status.Pass = agree ? FlowStatusPass.已通过 : FlowStatusPass.未通过;
                flow.Status.OverTime = DateTime.Now;
                //
                process.Operators.Add(operatorNow);
                coll.ReplaceOne(session, x => x.Id == id, flow);
                session.CommitTransaction();
                return (null, null);
            }
            else if (flow.CommonInfo.FlowDef.ApproveType == ApproveType.All)//会签找到当前操作人所有相关步骤,全部处理
            {
                var steps = flow.Process.Steps.FindAll(x => x.Agree is null && roles.Any(r => r.Rid == x.Role.Rid));
                if (steps.Count == 0) throw new Exception("未找到匹配的待处理步骤或此用户非待处理步骤角色");
                foreach (var step in steps)
                {
                    step.Operator = operatorNow;
                    step.OperateTime = DateTime.Now;
                    step.Agree = agree;
                    step.Comment = comment;
                }
                if (agree == false || process.Steps.Any(x => x.Agree == null) == false) //1.拒绝则流程结束 2.同意并且所有人均已操作则结束
                {
                    process.OperatorsNow = new List<FlowReferenceItem>(); //清空当前操作人
                    flow.Status.Pass = agree ? FlowStatusPass.已通过 : FlowStatusPass.未通过;
                    flow.Status.OverTime = DateTime.Now;
                }
                else
                {
                    process.OperatorsNow.RemoveAll(x => x.Rid == user); //移除当前操作人
                }
                //
                process.Operators.Add(operatorNow);
                coll.ReplaceOne(session, x => x.Id == id, flow);
                session.CommitTransaction();
                return (null, null);
            }
            else if (flow.CommonInfo.FlowDef.ApproveType == ApproveType.Continuous)
            {
                var step = process.Steps.First(x => x.Agree is null);
                if (step.No != process.StepNow) throw new Exception("error,process.stepNow is not eq to first null operate step");
                if (roles.Any(x => x.Rid == step.Role.Rid) == false) throw new Exception($"该待处理步骤需要角色[{step.Role.Name}],但该用户无此角色");
                step.Agree = agree;
                step.Operator = operatorNow;
                step.OperateTime = DateTime.Now;
                step.Comment = comment;
                process.OperatorsNow = new List<FlowReferenceItem>(); //清空当前操作人
                process.Operators.Add(operatorNow);//添加历史操作人
                if (agree == false || process.Steps.Any(x => x.Agree == null) == false)//流程结束
                {
                    flow.Status.Pass = FlowStatusPass.未通过;
                    flow.Status.OverTime = DateTime.Now;
                    return (null, null);
                }
                else
                {
                    var stepNext = process.Steps.First(x => x.Agree is null);
                    stepNext.StartTime = DateTime.Now;
                    process.StepNow += 1;
                    coll.ReplaceOne(session, x => x.Id == id, flow);
                    //get next operate users
                    var role = _flowRoles.Find(session, x => x.Id == stepNext.Role.Rid).Project(x => new NextRoleResult(x.IsApplyerDept, x.Users)).SingleOrDefault() ?? throw new Exception("the first step's role of this flow can not find in flowRoles");
                    return (flow, role);
                }
            }
            else if (flow.CommonInfo.FlowDef.ApproveType == ApproveType.Danymic)
            {
                return (null, null);
            }
            else throw new Exception("approveType error");
        }

        [HttpPost("ForInnerUsing/NextOperatorsAssign")] // 按分管分配下一步操作人
        public void NextOperatorsAssign(IClientSessionHandle session, Flow flow, NextRoleResult nextRoleResult, List<FlowReferenceItem> operators)
        {
            var nextOperatorRids = operators.Select(x => x.Rid);
            if (nextRoleResult.IsApplyerDept == false)
            {
                if (flow.CommonInfo.Creator.Org?.Rid is not null)
                {
                    var manageUsers = _flowUserManageDepts.Find(session, x => x.School == flow.School && nextOperatorRids.Contains(x.User.Rid) && x.Departments.Any(d => d.Rid == flow.CommonInfo.Creator.Org.Rid)).Project(x => x.User.Rid).ToList();
                    if (manageUsers.Count > 0) operators = operators.FindAll(o => manageUsers.Contains(o.Rid));
                }
            }
            coll.UpdateOne(session, x => x.Id == flow.Id, bu.Set(x => x.Process.OperatorsNow, operators));
        }

        [HttpGet("{id}/Detail")]
        public dynamic DetailGet(string id)
        {
            var obj = coll.Find(x => x.Id == id).Project(x => new { x.Business, x.BusinessKeyId, x.BusinessContents, x.Status, x.Process, x.CommonInfo }).Single();
            return new
            {
                obj.Business,
                obj.BusinessKeyId,
                obj.BusinessContents,
                Process = new
                {
                    Steps = obj.Process.Steps.Select(s => new
                    {
                        s.No,
                        s.Role,
                        s.Operator,
                        s.Agree,
                        s.OperateTime,
                        s.Comment
                    }),
                },
                obj.Status,
                CommonInfo = new
                {
                    obj.CommonInfo.Title,
                    Creator = new
                    {
                        obj.CommonInfo.Creator.Name,
                        obj.CommonInfo.Creator.Time,
                        Department = new { obj.CommonInfo.Creator.Org?.Name }
                    },
                    FlowInfo = new { obj.CommonInfo.FlowDef?.Name }
                }
            };
        }

        [Authorize]
        [HttpGet("{id}/MyApproveInfo")] //获取流程处理信息(步骤,当前是否为我的操作,我的上一次操作)
        public dynamic MyApproveInfoGet(string id)
        {
            var user = HttpContext.GetLoginUserFromToken();
            var obj = coll.Find(x => x.Id == id).Project(x => new { x.Status, x.Process, x.CommonInfo }).Single();
            return new
            {
                Process = new
                {
                    IsMyOperate = obj.Process.OperatorsNow.Any(o => o.Rid == user.Rid),
                    Steps = obj.Process.Steps.Select(s => new
                    {
                        s.No,
                        s.Role,
                        s.Operator,
                        s.Agree,
                        s.OperateTime,
                        s.Comment
                    }),
                },
                obj.Status,
                CommonInfo = new
                {
                    obj.CommonInfo.Title,
                    Creator = new
                    {
                        obj.CommonInfo.Creator.Name,
                        obj.CommonInfo.Creator.Time,
                        Department = new
                        {
                            obj.CommonInfo.Creator.Org?.Name,
                            obj.CommonInfo.Creator.Org?.Rid
                        }
                    },
                    FlowInfo = new { obj.CommonInfo.FlowDef?.Name }
                }
            };
        }




        [Authorize]
        [HttpPost("MyApprove/Page")]
        public FlowPageResult<dynamic> MyApprovePage(MyApprovePageInfo dto)
        {
            var user = HttpContext.GetLoginUserFromToken();
            var filter = bf.Eq(x => x.School, user.School);
            if (dto.Businesses != null && dto.Businesses.Length > 0) filter &= bf.In(x => x.Business.K, dto.Businesses);
            if (dto.IsApproved) filter &= bf.ElemMatch(x => x.Process.Operators, o => o.Rid == user.Rid);
            else filter &= bf.ElemMatch(x => x.Process.OperatorsNow, o => o.Rid == user.Rid);
            if (!string.IsNullOrWhiteSpace(dto.SearchKey)) filter &= bf.Where(x => x.CommonInfo.Creator.Name.Contains(dto.SearchKey) || x.CommonInfo.Title.Contains(dto.SearchKey));
            var query = coll.Find(filter);
            var total = query.CountDocuments();
            var listT = query.Project(x => new
            {
                x.Id,
                x.Business,
                x.BusinessKeyId,
                x.CommonInfo,
                x.Process.OperatorsNow,
                x.Process.StepNow,
                x.Process.Steps,
                x.Status
            }).SortByDescending(x => x.CommonInfo.Creator.Time).Skip((dto.PageIndex - 1) * dto.PageSize).Limit(dto.PageSize).ToList();
            return FlowPageResult.WrapDynamic(total, listT.Select(x => new
            {
                x.Id,
                x.Business,
                x.BusinessKeyId,
                x.CommonInfo,
                x.Status,
                x.OperatorsNow,
                StepCount = x.Steps.Count,
                StepNow = x.Steps.LastOrDefault(r => r.Operator != null),
                MyPreviousStep = x.Steps.LastOrDefault(s => s.Operator != null && s.Operator.Rid == user.Rid),
                IsMyOperate = x.OperatorsNow.FirstOrDefault(o => o.Rid == user.Rid) != null
            }));
        }

        public class MyApprovePageInfo : FlowKeywordPageInfo
        {
            public string[] Businesses { get; set; }
            public bool IsApproved { get; set; }
        }

        [Authorize]
        [HttpPost("MyApply/Page")]
        public FlowPageResult<dynamic> MyApplyPage(MyApplyPageInfo dto)
        {
            var user = HttpContext.GetLoginUserFromToken();
            var filter = bf.Eq(x => x.School, user.School) & bf.Eq(x => x.CommonInfo.Creator.Rid, user.Rid);
            if (dto.Businesses != null && dto.Businesses.Length > 0) filter &= bf.In(x => x.Business.K, dto.Businesses);
            if (!string.IsNullOrWhiteSpace(dto.SearchKey)) filter &= bf.Where(x => x.CommonInfo.Title.Contains(dto.SearchKey));
            var query = coll.Find(filter);
            var total = query.CountDocuments();
            var listT = query.Project(x => new
            {
                x.Id,
                x.Business,
                x.BusinessKeyId,
                x.CommonInfo,
                x.Process.OperatorsNow,
                x.Process.StepNow,
                x.Process.Steps,
                x.Status
            }).SortByDescending(x => x.CommonInfo.Creator.Time).Skip((dto.PageIndex - 1) * dto.PageSize).Limit(dto.PageSize).ToList();
            return FlowPageResult.WrapDynamic(total, listT.Select(x => new
            {
                x.Id,
                x.Business,
                x.BusinessKeyId,
                x.CommonInfo,
                x.Status,
                x.OperatorsNow,
                StepNow = x.Steps[x.StepNow - 1],
                StepCount = x.Steps.Count
            }));
        }

        public class MyApplyPageInfo : FlowKeywordPageInfo
        {
            public string[] Businesses { get; set; }
        }



        //[Authorize]
        //[HttpGet("{id}/Business")]
        //public Flow GetByBusinessId(string id) => coll.Find(x => x.BusinessKeyId == id).SingleOrDefault() ?? throw new Exception("no data find!");

        //[Authorize]
        //[HttpPost("Business")]
        //public List<Flow> GetByBusinessIds(string[] ids) => coll.Find(bf.In(x => x.BusinessKeyId, ids)).ToList();
    }

    #region dto_post

    public class FlowPostParam
    {
        [Required]
        public string School { get; set; }
        [Required]
        public string FlowDef { get; set; }
        [Required]
        public string BusinessKeyId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public FlowCreator Creator { get; set; }
    }

    public class NextRoleResult
    {
        public bool IsApplyerDept { get; }
        public List<FlowReferenceItem> Users { get; }

        public NextRoleResult(bool isApplyerDept, List<FlowReferenceItem> users)
        {
            IsApplyerDept = isApplyerDept;
            Users = users;
        }

    }

    #endregion dto_post

}

//var nextOperators = role.Users;
//var nextOperatorRids = nextOperators.Select(x => x.Rid);
////same department filter
//if (role.IsApplyerDept == true)
//{
//    if (flow.CommonInfo.Creator.Org?.Rid is null) throw new Exception("this flow creator's org is null");
//    nextOperators = _flowUserOrgs.Find(session, x => x.School == flow.School && x.Org.Rid == flow.CommonInfo.Creator.Org.Rid && nextOperatorRids.Contains(x.User.Rid)).Project(x => x.User).ToList();
//}
//else
//{
//    //manage department filter
//    if (flow.CommonInfo.Creator.Org?.Rid is not null)
//    {
//        var manageUsers = _flowUserManageDepts.Find(session, x => x.School == flow.School && nextOperatorRids.Contains(x.User.Rid) && x.Departments.Any(d => d.Rid == flow.CommonInfo.Creator.Org.Rid)).Project(x => x.User.Rid).ToList();
//        if (manageUsers.Count > 0) nextOperators = nextOperators.FindAll(o => manageUsers.Contains(o.Rid));
//    }
//}