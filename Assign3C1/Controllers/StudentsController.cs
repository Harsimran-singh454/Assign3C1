using Assign3C1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assign3C1.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        // GET: Students/list

        public ActionResult list()
        {
            StudentDataController controller = new StudentDataController();
            IEnumerable<Student> student = controller.listStudents();

            return View(student);
      
        }
    }
}