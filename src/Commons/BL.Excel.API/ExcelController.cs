using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BL.Excel.API.Controllers
{
    [Route("[controller]")]
    public class ExcelController : Controller
    {
        [HttpPost]
        public List<Dictionary<string, object>> Post([FromForm] IFormFile file)
        {
            if (file == null) throw new Exception("未找到文件");
            var list = ExcelHelper.GetDatas(file.OpenReadStream());
            return list;
        }
    }
}
