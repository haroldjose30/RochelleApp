using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class TestController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}