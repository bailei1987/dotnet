using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace example.api.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {

        //protected ILogger<WeatherForecastController> _logger;
        protected DbContext db;
    }
}
