using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
