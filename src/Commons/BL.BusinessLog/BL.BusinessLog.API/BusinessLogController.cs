using Microsoft.AspNetCore.Mvc;

namespace BL.BusinessLog.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BusinessLogController : ControllerBase
    {
        public BusinessLogController() { }
        

        [HttpPost("Page")]
        public BusinessLogPageResult<object> Page(BusinessLogKeywordPageInfo dto)
        {
            return BusinessLogHelper.Page(dto);
        }

    }

    
}