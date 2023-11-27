using Microsoft.AspNetCore.Mvc;

namespace WebLabApp.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
