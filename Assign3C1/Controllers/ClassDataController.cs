using Assign3C1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assign3C1.Controllers
{


    public class ClassDataController : ApiController
    {
        private SchoolDbContext data = new SchoolDbContext();


        /// <summary>
        /// Returns a classes of particular teacher who's id is passed in function
        /// </summary>
        /// <param name="id">the teacher ID</param>
        /// <returns>teacher's classes</returns>
        /// 
        [HttpGet]
    //    [Route("api/TeacherData/showCourses/{id}")]
        public IEnumerable<Classes> showCourses(int id)
        {
            Classes classes = new Classes();
            // Initiate Connection
            MySqlConnection Conn = data.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Create a new command for database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL command
            cmd.CommandText = "Select * from Classes where teacherid = " + id;

            MySqlDataReader Result = cmd.ExecuteReader();
            List<Classes> classlist = new List<Classes>();


            while (Result.Read())
            {
                string classcode = (string)Result["classcode"];
                string classname = (string)Result["classname"];

                classes.classcode = classcode;
                classes.classname = classname;

                classlist.Add(classes);
            }

            return classlist;
        }
    }
}
