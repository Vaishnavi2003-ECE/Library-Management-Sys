using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class borrowController : Controller
    {
        private readonly librarymagDbContext _context;

        public borrowController(librarymagDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new List<bookmasterModel>());
        }

        [HttpPost]
        public IActionResult search(string BookID, string BookName, string Author, int Quantity)
        {
            var books = _context.BookMaster.AsQueryable();

            if (!string.IsNullOrEmpty(BookID))
                books = books.Where(b => b.BookID.ToString() == (BookID));
            if (!string.IsNullOrEmpty(BookName))
                books = books.Where(b => b.BookName.Contains(BookName));
            if (!string.IsNullOrEmpty(Author))
                books = books.Where(b => b.Author.Contains(Author));
            if (Quantity > 0)
            {
                books = books.Where(b => b.Quantity >= Quantity);
            }
            var result = books.ToList();

            if (!result.Any())
            {
                TempData["Error"] = "No matching books found with the requested quantity.";
                return View("Index", new List<bookmasterModel>());
            }

            ViewBag.RequestedQuantity = Quantity;
            ViewBag.UserID = 1;
            return View("Index", result);
        }

        [HttpPost]
        public IActionResult BorrowBook(int BookID, int UserID, int Quantity)
        {
            try
            {
                var borrow = new returnModel
                {
                    BookID = BookID,
                    UserID = UserID,
                    Quantity = Quantity,
                    BorrowDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7),
                    IsReturned = false
                };

                _context.returnModel.Add(borrow);

                var book = _context.BookMaster.FirstOrDefault(b => b.BookID == BookID);
                if (book != null && book.Quantity >= Quantity)
                {
                    book.Quantity -= borrow.Quantity;
                }
                else
                {
                    TempData["Error"] = "Not enough stock available.";
                    return RedirectToAction("Index");
                }
                _context.SaveChanges();

                TempData["Success"] = "Book borrowed successfully!";
                return RedirectToAction("Index", "return");
            }
            catch (DbUpdateException ex)
            {
                var errorMessage = ex.InnerException?.Message ?? ex.Message;
                TempData["Error"] = "Database error: " + errorMessage;
                return RedirectToAction("Index");
            }
        }
    }
}
