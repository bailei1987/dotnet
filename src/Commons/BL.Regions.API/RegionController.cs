using BL.Regions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Regions.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<RegionCascaderItem> GetProvinceCityDistrict(int? level = null)
        {
            return RegionHelper.GetProvinceCityDistrict(level);
        }

        [HttpGet("GetChilds")]
        public IEnumerable<RegionCascaderItem> GetChilds(string parentCode = null)
        {
            return RegionHelper.GetChilds(parentCode);
        }

        [HttpPost("ByCodes")]
        public object GetByCodes(List<string[]> codes)
        {
            return RegionHelper.GetByCodes(codes);
        }
    }
}
