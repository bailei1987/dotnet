using BL.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace example.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        //public WeatherForecastController(ILogger<WeatherForecastController> logger, DbContext context)
        //{
        //    _logger = logger;
        //    db = context;
        //}
        public WeatherForecastController(DbContext context) => db = context;

        [HttpGet("Test")]
        public string Test()
        {
            _ = db.Test1s.DeleteMany(x => true);
            _ = db.Test2s.DeleteMany(x => true);
            var test1 = new Test1 { Name = "小白", Sex = ESex.MM };
            var test2 = new Test2 { Id = "xh", Name = "小黑", Sex = ESex.MM };
            db.Test1s.InsertOne(test1);
            db.Test2s.InsertOne(test2);
            var t1 = db.Test1s.Find(x => true).Single();
            var t2 = db.Test2s.Find(x => true).Single();
            return null;
        }
        [HttpGet]
        public string Get() => "WeatherForecast.API";

        [HttpPost]
        public List<Dictionary<string, object>> GetExcelDatas([FromForm] IFormFile file) => file == null ? throw new("未找到文件") : ExcelHelper.GetDatas(file.OpenReadStream());

        [HttpGet("Error")]
        public void GetError() => throw new("ExceptionMiddleware Test");
    }
}
