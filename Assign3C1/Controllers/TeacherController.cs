using Assign3C1.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Http.Cors;


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
        public ActionResult create(decimal salary, string teacherfname=null, string teacherlname = null, string employeenumber = null)
        {
         
            //Debug.WriteLine("Method Reached!");
            Debug.WriteLine("f-name:" + teacherfname +", l-name:" +teacherlname + ", empnum: "+employeenumber+ "salary: "+salary);
            
            // Teacher Object
            Teacher newTeacher = new Teacher();


            // Validating Data
            if (teacherfname == "" || teacherlname == "" || employeenumber == "")
            {
                return RedirectToAction("AddTeacher");
            }
            else { 
            newTeacher.teacherfname = teacherfname;
            newTeacher.teacherlname = teacherlname;
            newTeacher.employeenumber= employeenumber;
            newTeacher.salary= salary;
            newTeacher.hiredate= DateTime.Now;
            }
            TeacherDataController controller = new TeacherDataController();
            controller.addTeacherData(newTeacher);

            return RedirectToAction("List");

        }




        //GET: /Teacher/DeletePage/{id}

        public ActionResult DeletePage(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher teacher_info = controller.FindTeacher(id);

            return View(teacher_info);
        }


        //Post : /Teacher/DeleteConfirm/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.deleteTeacher(id);
            return RedirectToAction("List");
        }




        // GET: /Teacher/UpdateTeacher/{id}
        public ActionResult UpdateTeacher(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher teacher= controller.FindTeacher(id); 
            return View(teacher);
        }

        // POST: /Teacher/update
        public ActionResult update(int id, decimal salary, string teacherfname = null, string teacherlname = null, string employeenumber = null)
        {
            TeacherDataController controller= new TeacherDataController();
            Teacher teacherData = new Teacher();

            teacherData.teacherid = id;
            teacherData.teacherfname = teacherfname;
            teacherData.teacherlname = teacherlname;
            teacherData.salary = salary;
            teacherData.employeenumber=employeenumber;


            controller.UpdateTeacher(id, teacherData);

            return RedirectToAction("List");

        }
    }
}