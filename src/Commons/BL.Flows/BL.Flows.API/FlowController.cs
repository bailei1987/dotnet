using BL.Flows.API.Models;
using BL.Flows.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Linq;

namespace BL.Flows.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlowController : ControllerBase
    {
        //private readonly IMongoDatabase db;
        private readonly IMongoCollection<Flow> coll;
        //private readonly IMongoCollection<FlowBusiness> _flowBusinesses;
        //private readonly IMongoCollection<FlowDef> _flowDefs;
        //private readonly IMongoCollection<FlowRole> _flowRoles;
        //private readonly IMongoCollection<FlowUserManageDept> _flowUserManageDepts;

        public FlowController(IMongoDatabase db)
        {
            //this.db = db;
            coll = db.GetCollection<Flow>(CollNames.Flow);
            //_flowBusinesses = db.GetCollection<FlowBusiness>(CollNames.FlowBusiness);
            //_flowDefs = db.GetCollection<FlowDef>(CollNames.FlowDef);
            //_flowRoles = db.GetCollection<FlowRole>(CollNames.FlowRole);
            //_flowUserManageDepts = db.GetCollection<FlowUserManageDept>(CollNames.FlowUserManageDept);
        }

        private readonly FilterDefinitionBuilder<Flow> bf = Builders<Flow>.Filter;

        //[HttpPost("ForInnerUsing/NextOperatorsAssign")] // 按分管分配下一步操作人
        //public void NextOperatorsAssign(IClientSessionHandle session, Flow flow, bool isApplyerDept, List<FlowReferenceItem> operators)
        //{
        //    var nextOperatorRids = operators.Select(x => x.Rid);
        //    if (isApplyerDept == false)
        //    {
        //        if (flow.CommonInfo.Creator.Org?.Rid is not null)
        //        {
        //            var manageUsers = _flowUserManageDepts.Find(session, x => x.School == flow.School && nextOperatorRids.Contains(x.User.Rid) && x.Departments.Any(d => d.Rid == flow.CommonInfo.Creator.Org.Rid)).Project(x => x.User.Rid).ToList();
        //            if (manageUsers.Count > 0) operators = operators.FindAll(o => manageUsers.Contains(o.Rid));
        //        }
        //    }
        //    coll.UpdateOne(session, x => x.Id == flow.Id, bu.Set(x => x.Process.OperatorsNow, operators));
        //}


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
            var user = HttpContext.GetFlowLoginUserFromToken();
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
            var user = HttpContext.GetFlowLoginUserFromToken();
            var filter = bf.Eq(x => x.School, user.School);
            if (dto.Businesses != null && dto.Businesses.Length > 0) filter &= bf.In(x => x.Business.K, dto.Businesses);
            if (dto.ExceptDynamic) filter &= bf.Ne(x => x.CommonInfo.FlowDef.ApproveType, ApproveType.Danymic);
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
            public bool ExceptDynamic { get; set; } = true;
            public string[] Businesses { get; set; }
            public bool IsApproved { get; set; }
        }

        [Authorize]
        [HttpPost("MyApply/Page")]
        public FlowPageResult<dynamic> MyApplyPage(MyApplyPageInfo dto)
        {
            var user = HttpContext.GetFlowLoginUserFromToken();
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