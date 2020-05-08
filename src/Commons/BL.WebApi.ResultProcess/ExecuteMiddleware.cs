using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BL.WebApi.ResultProcess
{
    public class ExceptionMiddleware : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new { StatusCode = HttpStatusCode.InternalServerError, Msg = context.Exception.Message, Data = default(object) });
            base.OnException(context);
        }
    }
    public class ExecuteMiddleware : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is null)
            {
                if (context.Result is ObjectResult)
                {
                    context.Result = new ObjectResult(new { StatusCode = HttpStatusCode.OK, Msg = "success", Data = ((ObjectResult)context.Result).Value });
                }
                else if (context.Result is EmptyResult)
                {
                    context.Result = new ObjectResult(new { StatusCode = HttpStatusCode.OK, Msg = "success", Data = default(object) });
                }
            }
            base.OnActionExecuted(context);
        }
    }
}
