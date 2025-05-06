using Microsoft.AspNetCore.Mvc;

namespace LabraryManagement.Controllers
{
    public class DashController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
