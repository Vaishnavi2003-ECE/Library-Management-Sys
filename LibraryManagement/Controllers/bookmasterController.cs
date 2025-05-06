using System.Data;
using LabraryManagement.Models;
using Microsoft.AspNetCore.Mvc;



namespace LabraryManagement.Controllers
{
    public class bookmasterController : Controller
    {
        private static List<bookmasterModel> _bookList = new List<bookmasterModel>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(_bookList);
        }

        [HttpPost]
        public IActionResult Index(bookmasterModel model)
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
