﻿using Microsoft.AspNetCore.Mvc;

namespace BL.BusinessLog.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BusinessLogController : ControllerBase
    {
        [HttpPost("Page")]
        public BusinessLogPageResult<object> Page(BusinessLogKeywordPageInfo dto)
        {
            return BusinessLogHelper.Page(dto);
        }
    }
}