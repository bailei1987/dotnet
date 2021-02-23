using BL.Flows.Domain;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

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
            if (coll.CountDocuments(x => x.K == dto.K || x.V == dto.V) > 0) throw new("business has already exist");
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
            _ = coll.DeleteOne(x => x.K == k);
        }
    }
}