using Microsoft.AspNetCore.Mvc;

namespace SchoolPortal.Controllers
{
    public class FirstPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
