using Microsoft.AspNetCore.Mvc;

namespace sebsa.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index() { return View(); }
        [HttpPost]
        public IActionResult Logar(string email, string senha) { return Json(new {}); }
    }
}
