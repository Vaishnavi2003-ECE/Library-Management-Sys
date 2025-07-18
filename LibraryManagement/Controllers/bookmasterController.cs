using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace LibraryManagement.Controllers
{
    public class bookmasterController : Controller
    {
        private readonly librarymagDbContext _context;

        public bookmasterController(librarymagDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = _context.BookMaster.ToList();
            return View(books);
        }

        [HttpPost]
        public IActionResult Index(bookmasterModel model)
        {
            if (ModelState.IsValid)
            {
                _context.BookMaster.Add(model);
                _context.SaveChanges();


                return RedirectToAction("Index");
            }
            var books = _context.BookMaster.ToList();
            return View(books);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var books = _context.BookMaster.FirstOrDefault(b => b.BookID == id);
            if (books != null)
            {
                _context.BookMaster.Remove(books);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        
    }
}
