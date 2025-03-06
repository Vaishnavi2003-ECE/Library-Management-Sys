using LabraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabraryManagement.Controllers
{
    public class borrowController : Controller
    {
        private static List<borrowModel> _bookList = new List<borrowModel>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(_bookList);
        }

        [HttpPost]
        public IActionResult Index(borrowModel model)
        {
            if (ModelState.IsValid)
            {
                _bookList.Add(model); // Add the book to the list

                // Redirect to the Index page after saving
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
