using System;
using System.Collections.Generic;
using BL.Flows.API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BL.Flows.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlowBusinessController : ControllerBase
    {
        private readonly IMongoCollection<FlowBusiness> coll;

        public FlowBusinessController(IMongoDatabase db) { coll = db.GetCollection<FlowBusiness>(CollNames.FlowBusiness); }

        [HttpPost]
        public void Post(FlowBusiness dto)
        {
            if (coll.CountDocuments(x => x.K == dto.K || x.V == dto.V) > 0) throw new Exception("business has already exist");
            coll.InsertOne(dto);
        }

        [HttpGet]
        public IEnumerable<FlowBusiness> Get()
        {
            return coll.Find(x => true).ToList();
        }

        [HttpDelete("{k}")]
        public void Delete(string k)
        {
            coll.DeleteOne(x => x.K == k);
        }



    }
}