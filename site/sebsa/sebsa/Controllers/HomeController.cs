using Microsoft.AspNetCore.Mvc;

namespace sebsa.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
