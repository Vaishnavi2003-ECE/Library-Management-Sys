using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.Username == "admin" && model.Password == "admin" )
                {

                    return RedirectToAction("Index", "Dash");
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect UserId and Password This One, try again.";
                    
                }
            }

            return View(model);
        }
    }
}


