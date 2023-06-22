using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
