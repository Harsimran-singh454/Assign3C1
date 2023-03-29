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
            IEnumerable<Teacher> Teachers = controller.teachersList();
           
            return View(Teachers);
        }


        // GET: /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher teacher_info = controller.showTeacher(id);
            
            return View(teacher_info);
        }



        // GET: /Teacher/search/{req}

        public ActionResult search(string req)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> search_result = controller.teachersSearch(req);
            
            return View(search_result);
        }

    }
}