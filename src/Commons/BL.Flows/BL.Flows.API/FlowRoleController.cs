﻿using BL.Flows.API.Dtos;
using BL.Flows.API.Models;
using BL.Flows.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BL.Flows.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlowRoleController : ControllerBase
    {
        private readonly IMongoCollection<FlowRole> coll;

        public FlowRoleController(IMongoDatabase db) { coll = db.GetCollection<FlowRole>(CollNames.FlowRole); }

        private readonly FilterDefinitionBuilder<FlowRole> bf = Builders<FlowRole>.Filter;
        private readonly UpdateDefinitionBuilder<FlowRole> bu = Builders<FlowRole>.Update;

        #region basic

        [Authorize]
        [HttpPost("Page")]
        public FlowPageResult<object> Page(FlowKeywordPageInfo dto)
        {
            var user = HttpContext.GetFlowLoginUserFromToken();
            var filter = bf.Eq(x => x.School, user.School);
            if (!string.IsNullOrWhiteSpace(dto.SearchKey)) filter &= bf.Where(x => x.Name.Contains(dto.SearchKey));
            var query = coll.Find(filter);
            var total = query.CountDocuments();
            var list = query.Project(x => new
            {
                x.Id,
                x.Name,
                x.Desc,
                x.IsSystematic,
                x.IsApplyerDept,
                x.IsFlowRole,
                UsersStr = string.Join(',', x.Users.Select(u => u.Name)),
            }).SortBy(x => x.Name).Skip((dto.PageIndex - 1) * dto.PageSize).Limit(dto.PageSize).ToList();
            return FlowPageResult.WrapDynamic(total, list);
        }

        [HttpGet]
        public IEnumerable<FlowReferenceItem> Get()
        {
            return coll.Find(bf.And(bf.Eq(x => x.School, HttpContext.GetFlowLoginUserFromToken().School), bf.Eq(x => x.IsFlowRole, true))).Project(x => new FlowReferenceItem(x.Id, x.Name)).ToList();
        }

        [HttpGet("{id}")]
        public FlowRole Get(string id)
        {
            return coll.Find(x => x.Id == id).Single();
        }

        [Authorize]
        [HttpPost]
        public void Post(FlowRoleDtoPost dto)
        {
            var user = HttpContext.GetFlowLoginUserFromToken();
            if (coll.CountDocuments(x => x.School == user.School && x.Name == dto.Name) > 0) throw new("该流程角色名称已存在");
            var obj = dto.GetMapClass();
            obj.Creator = user.ToOperator();
            obj.School = user.School;
            coll.InsertOne(obj);
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Put(string id, FlowRoleDtoPut dto)
        {
            var obj = coll.Find(x => x.Id == id).SingleOrDefault() ?? throw new("no data find");
            if (obj.IsSystematic) throw new("该流程角色为系统内定，无法修改");
            if (obj.Name == "班主任") throw new("班主任角色为系统内定，无法修改");
            var update = bu.Set(x => x.Desc, dto.Desc)
                .Set(x => x.IsApplyerDept, dto.IsApplyerDept)
                .Set(x => x.IsFlowRole, dto.IsFlowRole)
                .Set(x => x.Name, dto.Name);
            _ = coll.UpdateOne(x => x.Id == id, update);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var obj = coll.Find(x => x.Id == id).SingleOrDefault() ?? throw new("no data find");
            if (obj.IsSystematic) throw new("该流程角色为系统内定，无法删除");
            if (obj.Users.Count > 0) throw new("该流程角色下有用户,无法删除");
            _ = coll.DeleteOne(x => x.Id == id);
        }

        #endregion basic

        #region users

        [HttpGet("{id}/Users")]
        public IEnumerable<FlowReferenceItem> UsersGet(string id)
        {
            return coll.Find(x => x.Id == id).Project(x => x.Users).SingleOrDefault() ?? throw new("no data find or users is null");
        }

        [Authorize]
        [HttpPut("{id}/Users")]
        public void UsersPut(string id, List<FlowReferenceItem> users)
        {
            if (coll.UpdateOne(x => x.Id == id, bu.Set(x => x.Users, users)).ModifiedCount == 0) throw new("error,no data updated");
        }

        [Authorize]
        [HttpPost("{id}/User")]
        public void UserPost(string id, FlowReferenceItem dto)
        {
            var users = coll.Find(x => x.Id == id).Project(x => x.Users).SingleOrDefault() ?? throw new("no data find or users is null");
            if (users.Exists(x => x.Rid == dto.Rid)) throw new("该流程角色已有该用户");
            users.Add(dto);
            users.Sort((x, y) => string.CompareOrdinal(x.Name, y.Name));
            _ = coll.UpdateOne(x => x.Id == id, bu.Set(x => x.Users, users));
        }

        [Authorize]
        [HttpDelete("{id}/User/{sid}")]
        public void UserDelete(string id, string sid)
        {
            if (coll.UpdateOne(x => x.Id == id, bu.PullFilter(x => x.Users, x => x.Rid == sid)).ModifiedCount == 0) throw new("该流程角色下无此用户");
        }

        #endregion users
    }
}