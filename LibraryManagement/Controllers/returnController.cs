using Microsoft.AspNetCore.Mvc;

namespace LabraryManagement.Controllers
{
    public class returnController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
