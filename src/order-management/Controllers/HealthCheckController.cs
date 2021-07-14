using Microsoft.AspNetCore.Mvc;

namespace order_management.Controllers
{
    [Route("api/[controller]")]
    public class HealthCheckController : Controller
    {
        // GET: api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello world!";
        }
    }
}
