using Microsoft.AspNetCore.Mvc;

namespace SalesOrderManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
