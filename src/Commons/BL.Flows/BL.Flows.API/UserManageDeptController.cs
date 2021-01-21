using System;
using System.Linq;
using BL.Flows.API.Dtos;
using BL.Flows.API.Models;
using BL.Flows.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BL.Flows.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserManageDeptController : ControllerBase
    {
        private readonly IMongoCollection<FlowUserManageDept> coll;

        public UserManageDeptController(IMongoDatabase db) { coll = db.GetCollection<FlowUserManageDept>(CollNames.FlowUserManageDept); }

        private readonly FilterDefinitionBuilder<FlowUserManageDept> bf = Builders<FlowUserManageDept>.Filter;
        private readonly UpdateDefinitionBuilder<FlowUserManageDept> bu = Builders<FlowUserManageDept>.Update;

        #region basic

        [Authorize]
        [HttpPost("Page")]
        public FlowPageResult<object> Page(FlowKeywordPageInfo dto)
        {
            var user = HttpContext.GetFlowLoginUserFromToken();
            var filter = bf.Eq(x => x.School, user.School);
            if (!string.IsNullOrWhiteSpace(dto.SearchKey)) filter &= bf.Where(x => x.User.Name.Contains(dto.SearchKey));
            var query = coll.Find(filter);
            var total = query.CountDocuments();
            var list = query.Project(x => new
            {
                x.Id,
                x.User,
                DepartmentsStr = string.Join(',', x.Departments.Select(u => u.Name)),
            }).SortBy(x => x.User.Name).Skip((dto.PageIndex - 1) * dto.PageSize).Limit(dto.PageSize).ToList();
            return FlowPageResult.WrapDynamic(total, list);
        }

        [HttpGet("{id}")]
        public object Get(string id)
        {
            return coll.Find(x => x.Id == id).Project(x => new
            {
                x.Id,
                x.User,
                x.Departments
            }).SingleOrDefault() ?? throw new Exception("no data find");
        }

        [Authorize]
        [HttpPost]
        public void Post(FlowUserManageDeptDtoPost dto)
        {
            var user = HttpContext.GetFlowLoginUserFromToken();
            if (coll.CountDocuments(x => x.User.Rid == dto.User.Rid) > 0) throw new Exception("已添加该用户设置,请使用编辑");
            var obj = dto.GetMapClass();
            obj.Creator = user.ToOperator();
            obj.School = user.School;
            coll.InsertOne(obj);
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Put(string id, FlowUserManageDeptDtoPut dto)
        {
            var update = bu.Set(x => x.User, dto.User).Set(x => x.Departments, dto.Departments);
            if (coll.UpdateOne(x => x.Id == id, update).MatchedCount == 0) throw new Exception("no data find");
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            coll.DeleteOne(x => x.Id == id);
        }

        #endregion basic

    }
}