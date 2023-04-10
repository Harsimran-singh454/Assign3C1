using Assign3C1.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
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


        // GET: /Teacher/AddTeacher

        public ActionResult AddTeacher()
        {
            return View();
        }

        //POST: /Teacher/create

        [HttpPost]
        public ActionResult create(string teacherfname, string teacherlname, string employeenumber, decimal salary)
        {
         
            Debug.WriteLine("Method Reached!");
            Debug.WriteLine("f-name:" + teacherfname +", l-name:" +teacherlname + ", empnum: "+employeenumber+ "salary: "+salary);

            Teacher newTeacher = new Teacher();

            newTeacher.teacherfname = teacherfname;
            newTeacher.teacherlname = teacherlname;
            newTeacher.employeenumber= employeenumber;
            newTeacher.salary= salary;
            newTeacher.hiredate= DateTime.Now;

            TeacherDataController controller = new TeacherDataController();
            controller.addTeacherData(newTeacher);

            return RedirectToAction("List");

        }

        //Post : /Teacher/DeleteConfirm/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.deleteTeacher(id);
            return RedirectToAction("List");
        }


        //GET: /Teacher/DeletePage/{id}

        public ActionResult DeletePage(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher teacher_info = controller.FindTeacher(id);

            return View(teacher_info);
        }

    }
}