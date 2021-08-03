using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BL.Dictionary.MongoDB
{
    [Route("[controller]")]
    public class DictionaryController : Controller
    {
        private readonly DictionaryManager _manager;
        public DictionaryController(DictionaryManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public void Post(DictionaryItem dto) => _manager.Post(dto);

        [HttpPut]
        public void Put(DictionaryItem dto) => _manager.Put(dto);

        [HttpGet("{id}")]
        public DictionaryItem Get(string id) => _manager.Get(id);

        [HttpDelete("{id}")]
        public void Delete(string id) => _manager.Delete(id);

        [HttpGet("ByType/{type}")]
        public List<DictionaryItem> GetByType(string type) => _manager.GetByType(type);

        [HttpGet("ByTypes/{types}")]
        public Dictionary<string, List<DictionaryItemKV>> GetByTypes(string types) => _manager.GetByTypes(types.Split(","));

        [HttpGet("Status")]
        public IEnumerable<object> GetStatus() => _manager.GetStatus();
    }
}
