using Assign3C1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assign3C1.Controllers
{
    public class ClassController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Courses(int id)
        {
            ClassDataController controller = new ClassDataController();
            IEnumerable<Classes> classes_ = controller.showCourses(id);

            return View(classes_);
        }
    }
}