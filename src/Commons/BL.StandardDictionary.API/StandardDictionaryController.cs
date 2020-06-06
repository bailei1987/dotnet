using System.Collections.Generic;
using System.Linq;
using BL.StandardDictionary;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StandardDictionary.API.Controllers
{
    [Route("[controller]")]
    public class StandardDictionaryController : Controller
    {
        [HttpGet]
        public DicItem[] Get(string key)
        {
            var dic = DicItem.GetDics(key).ElementAt(0).Value;
            return dic;
        }
        [HttpGet("Many")]
        public Dictionary<string, DicItem[]> GetMany(string keys)
        {
            var dics = DicItem.GetDics(keys.Split(","));
            return dics;
        }
    }
}
