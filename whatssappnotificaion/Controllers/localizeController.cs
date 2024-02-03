using Microsoft.AspNetCore.Mvc;
using whatssappnotificaion.Models.localize;

namespace whatssappnotificaion.Controllers
{
    public class localizeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult createkey()
        {
            return View();
        }
        [HttpPost]
        public IActionResult createkey(Language language)
        {
            return View();
        }
    }
}
