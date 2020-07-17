using System;
using System.Collections.Generic;
using System.Linq;
using BL.Excel;
using BL.Common;
using BL.StandardDictionary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models;
using MongoDB.Driver;

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
        public WeatherForecastController(DbContext context)
        {
            db = context;
        }
        [HttpGet("Test")]
        public string Test()
        {

            return null;
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return db.WeatherForecasts.Find(x => true).ToList();
        }

        [HttpPost]
        public List<Dictionary<string, object>> GetExcelDatas([FromForm] IFormFile file)
        {
            if (file == null) throw new Exception("未找到文件");
            var list = ExcelHelper.GetDatas(file.OpenReadStream());
            return list;
        }

    }
}
