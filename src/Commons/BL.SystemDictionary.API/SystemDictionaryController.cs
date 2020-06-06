using System.Collections.Generic;
using BL.SystemDictionary;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SystemDictonary.API.Controllers
{
    [Route("[controller]")]
    public class SystemDictionaryController : ControllerBase
    {
        public SystemDictionaryController() { }

        [HttpGet("{type}")]
        public IEnumerable<SystemDictionaryKV> Get(string type)
        {
            return SystemDictionary.Get(type);
        }
        [HttpGet("Many/{types}")]
        public Dictionary<string, List<SystemDictionaryKV>> GetMany(string types)
        {
            return SystemDictionary.GetMany(types.Split(',', '|', ' '));
        }
    }
}
