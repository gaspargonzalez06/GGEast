using Microsoft.AspNetCore.Mvc;

namespace GGEats.Controllers
{
    public class AddOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nav()
        {
            return View();
        }
    }
}
