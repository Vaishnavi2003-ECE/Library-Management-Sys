using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class DashController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
