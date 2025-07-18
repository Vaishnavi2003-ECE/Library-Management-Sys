using System.Linq;
using LibraryManagement.Models;
using LibraryManagement.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class usermasterController : Controller
    {
        private readonly librarymagDbContext _context;
        public usermasterController(librarymagDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _context.UserMaster.ToList();
            return View(users);
        }

        [HttpPost]
        public IActionResult Index(usermasterModel model)
        {
            if (ModelState.IsValid)
            {
                _context.UserMaster.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            var users = _context.UserMaster.ToList();
            return View(users);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var users = _context.UserMaster.FirstOrDefault(u => u.UserID == id);
            if (users != null)
            {
                _context.UserMaster.Remove(users);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
       
        }

    }

}
