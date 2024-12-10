using Microsoft.AspNetCore.Mvc;

namespace odevweb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminPanel() 
        {
            return View();
        }
    }
}
