using System;
using System.Collections.Generic;
using System.Linq;
using BL.Flows.API.Dtos;
using BL.Flows.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BL.Flows.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlowDefController : ControllerBase
    {
        private readonly IMongoCollection<FlowDef> coll;

        public FlowDefController(IMongoDatabase db) { coll = db.GetCollection<FlowDef>(CollNames.FlowDef); }

        private readonly FilterDefinitionBuilder<FlowDef> bf = Builders<FlowDef>.Filter;
        private readonly UpdateDefinitionBuilder<FlowDef> bu = Builders<FlowDef>.Update;

        #region basic

        [Authorize]
        [HttpPost("Page")]
        public FlowPageResult<FlowDef> Page(FlowKeywordPageInfo dto)
        {
            var user = HttpContext.GetLoginUserFromToken();
            var filter = bf.Eq(x => x.School, user.School) & bf.In(x => x.ApproveType, new[] { ApproveType.All, ApproveType.Continuous, ApproveType.Or });
            if (!string.IsNullOrWhiteSpace(dto.SearchKey)) filter &= bf.Where(x => x.Name.Contains(dto.SearchKey));
            var query = coll.Find(filter);
            var total = query.CountDocuments();
            var list = query.SortBy(x => x.Name).Skip((dto.PageIndex - 1) * dto.PageSize).Limit(dto.PageSize).ToList();
            return FlowPageResult.Wrap(total, list);
        }

        [HttpGet("{id}")]
        public object Get(string id)
        {
            return coll.Find(x => x.Id == id).Project(x => new
            {
                x.Id,
                x.Name,
                x.Steps,
                x.StepsCount,
                x.ApproveType,
                x.BusinessType
            }).SingleOrDefault() ?? throw new Exception("no data find");
        }

        [Authorize]
        [HttpPost]
        public void Post(FlowDefDtoPost dto)
        {
            var user = HttpContext.GetLoginUserFromToken();
            if (coll.CountDocuments(x => x.School == user.School && x.Name == dto.Name) > 0) throw new Exception("该流程名称已存在");
            var obj = dto.GetMapClass();
            obj.Creator = user.ToOperator();
            obj.School = user.School;
            coll.InsertOne(obj);
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Put(string id, FlowDefDtoPut dto)
        {
            var obj = coll.Find(x => x.Id == id).SingleOrDefault();
            if (obj == null) throw new Exception("no data find");
            coll.UpdateOne(x => x.Id == id, bu.Set(x => x.Name, dto.Name)
                .Set(x => x.ApproveType, dto.ApproveType)
                .Set(x => x.BusinessType, dto.BusinessType)
                .Set(x => x.StepsCount, dto.StepsCount)
                .Set(x => x.Steps, dto.Steps.Select(x => x.GetMapClass())));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            if (coll.DeleteOne(x => x.Id == id).DeletedCount == 0) throw new Exception("no data find");
        }

        #endregion basic

        [Authorize]
        [HttpGet("ByBusiness/{flowBusiness}")]
        public IEnumerable<dynamic> GetByBusiness(string flowBusiness)
        {
            var user = HttpContext.GetLoginUserFromToken();
            return coll.Find(x => x.BusinessType.K == flowBusiness && x.School == user.School).Project(x => new { Rid = x.Id, x.Name, x.ApproveType }).ToList();
        }

    }
}