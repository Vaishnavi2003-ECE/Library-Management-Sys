using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class returnController : Controller
    {
        private readonly librarymagDbContext _context;

        public returnController(librarymagDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AddReturn()
        {
            var record = _context.returnModel.FirstOrDefault(); // Ensure this fetches valid data
            return View(record);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var records = _context.returnModel
                .Select(borrow => new returnModel
                {
                     BorrowID = borrow.BorrowID,
                     BookID = borrow.BookID,
                     BookName = _context.BookMaster
                                         .Where(b => b.BookID == borrow.BookID)
                                         .Select(b => b.BookName)
                                         .FirstOrDefault(),
                     UserID = borrow.UserID,
                     UserName = _context.UserMaster
                                         .Where(u => u.UserID == borrow.UserID)
                                         .Select(u => u.UserName)
                                         .FirstOrDefault(),
                     Quantity = borrow.Quantity,
                     BorrowDate = borrow.BorrowDate,
                     DueDate = borrow.DueDate,
                     IsReturned = borrow.IsReturned
                }).ToList();

        return View(records);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Return(int BorrowID)
        {
            var record = _context.returnModel.FirstOrDefault(r => r.BorrowID == BorrowID);
            if (record != null)
            {
                record.IsReturned = true;

                var book = _context.BookMaster.FirstOrDefault(b => b.BookID == record.BookID);
                if (book != null)
                {
                    book.Quantity += record.Quantity;
                }

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
