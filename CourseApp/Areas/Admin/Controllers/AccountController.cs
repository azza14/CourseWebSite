using CourseApp.Areas.Admin.Models;
using CourseApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseApp.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login( LoginModel loginInfo)
        {
            var adminService = new AdminServices();
            var isLoggedIn = adminService.Login(loginInfo.Email, loginInfo.Password);
            if (isLoggedIn)
            {
                return RedirectToAction("Index","Default");
            }
            else
            {
                loginInfo.Message  = "Email or Password is no Correct";
                return View(loginInfo);
            }

        }
    }
}