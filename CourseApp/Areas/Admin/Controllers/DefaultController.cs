using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseApp.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Admin/Courses
        public ActionResult Index()
        {
            return View();
        }
    }
}