using Microsoft.AspNetCore.Mvc;

namespace E_Web_NET_CORE.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
