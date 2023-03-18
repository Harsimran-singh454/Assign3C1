using Assign3C1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Assign3C1.Controllers
{
    public class TeacherController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        // GET : /Teacher/List
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teachers> Teacher = controller.teachersList();
           
            return View(Teacher);
        }


        // GET: /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teachers newTeacher = controller.showTeacher(id);
            
            return View(newTeacher);
        }


    }
}