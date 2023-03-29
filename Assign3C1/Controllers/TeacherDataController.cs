using Assign3C1.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;





namespace Assign3C1.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext data = new SchoolDbContext();

        //This Controller is for accessing teachers data.
        
        
        
        
        
        /// <summary>
        /// Returns a list of teachers
        /// </summary>
        /// <example>GET api/TeacherData/teacherList</example>
        /// <returns>
        /// A list of teachers
        /// </returns>
        
        [HttpGet]
        public IEnumerable<Teacher> teachersList()
        {
            // Initiate Connection
            MySqlConnection Conn = data.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Create a new command for database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL command
            cmd.CommandText = "Select * from Teachers";


            MySqlDataReader Result = cmd.ExecuteReader();

            List<Teacher> Teacher = new List<Teacher>();

            //Loop Through Each Row the Result Set
            while (Result.Read())
            {
                //Access Column information by the DB column name as an index

                int t_id = (int)Result["teacherid"];
                string tFirstName = (string)Result["teacherfname"];
                string tLastName = (string)Result["teacherlname"];
                DateTime hiredate = (DateTime)Result["hiredate"];
                decimal salary = (decimal)Result["salary"];

                Teacher newTeacher = new Teacher();
                newTeacher.teacherid = t_id;
                newTeacher.teacherfname = tFirstName;
                newTeacher.teacherlname = tLastName;
                newTeacher.hiredate = hiredate;
                newTeacher.salary = salary;

                //Add the Author Name to the List

                Teacher.Add(newTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return Teacher;
        }






        /// <summary>
        /// Returns a teacher from the database according to the primary key teacherid
        /// </summary>
        /// <param name="id">the teacher's ID</param>
        /// <returns>teacher's properties</returns>
        [HttpGet]
        public Teacher showTeacher(int id)
        {
            Teacher newTeacher = new Teacher();
            // Initiate Connection
            MySqlConnection Conn = data.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Create a new command for database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL command
            cmd.CommandText = "Select * from Teachers where teacherid = " + id;

            MySqlDataReader Result = cmd.ExecuteReader();


            while (Result.Read())
            {
                int t_id = (int)Result["teacherid"];
                string employeenumber = (string)Result["employeenumber"];
                string tFirstName = (string)Result["teacherfname"];
                string tLastName = (string)Result["teacherlname"];
                DateTime hiredate = (DateTime)Result["hiredate"];
                decimal salary = (decimal)Result["salary"];

                newTeacher.teacherid = t_id;
                newTeacher.employeenumber = employeenumber;
                newTeacher.teacherfname = tFirstName;
                newTeacher.teacherlname = tLastName;
                newTeacher.hiredate = hiredate;
                newTeacher.salary = salary;
            }

            return newTeacher;
        }






        /// <summary>
        /// Returns the searched item from the teachers database
        /// </summary>
        /// <param name="req">the input key</param>
        /// <returns>Matching Result</returns>
        [HttpGet]
        [Route("api/teacherdata/teachersearch/{search?}")]
        public IEnumerable<Teacher> teachersSearch(string input = null)
        {
            // Initiate Connection
            MySqlConnection Conn = data.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Create a new command for database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL command
            cmd.CommandText = "Select * from Teachers where teacherfname = " + input;
            cmd.Parameters.AddWithValue("@key", "%" + input + "%");
            cmd.Prepare();
            MySqlDataReader Result = cmd.ExecuteReader();

            List<Teacher> Teacher = new List<Teacher>();

            //Loop Through Each Row the Result Set
            while (Result.Read())
            {
                //Access Column information by the DB column name as an index

                int t_id = (int)Result["teacherid"];
                string tFirstName = (string)Result["teacherfname"];
                string tLastName = (string)Result["teacherlname"];
                DateTime hiredate = (DateTime)Result["hiredate"];
                decimal salary = (decimal)Result["salary"];

                Teacher newTeacher = new Teacher();
                newTeacher.teacherid = t_id;
                newTeacher.teacherfname = tFirstName;
                newTeacher.teacherlname = tLastName;
                newTeacher.hiredate = hiredate;
                newTeacher.salary = salary;

                //Add the Author Name to the List

                Teacher.Add(newTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();
            //Return the final list of author names
            return Teacher;
        }


    }
}
