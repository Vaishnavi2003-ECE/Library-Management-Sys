using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;


namespace LibraryManagement.Controllers
{
    public class searchController : Controller
    {
        private static List<searchModel> _bookList = new List<searchModel>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(_bookList);
        }

        [HttpPost]
        public IActionResult Index(searchModel model)
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

