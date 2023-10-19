using Microsoft.AspNetCore.Mvc;

namespace ProjectD.Conrollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
