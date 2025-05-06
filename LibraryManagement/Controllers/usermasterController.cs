using LabraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabraryManagement.Controllers
{
    public class usermasterController : Controller
    {
        private static List<usermasterModel> _bookList = new List<usermasterModel>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(_bookList);
        }

        [HttpPost]
        public IActionResult Index(usermasterModel model)
        {
            if (ModelState.IsValid)
            {
                _bookList.Add(model);

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }

}
