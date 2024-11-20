using Microsoft.AspNetCore.Mvc;

namespace RaizesUrbanaWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SobreNos()
        {
            return View();
        }

        public IActionResult Entregas()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
