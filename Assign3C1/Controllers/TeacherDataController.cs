using Assign3C1.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Datatypes;
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
            cmd.CommandText = "Select * from Teachers where teacherfname = @input";
            cmd.Parameters.AddWithValue("@key", "%@input%");
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





        /// <summary>
        /// Creates a record (new teacher in the database)
        /// </summary>
        /// <param name="newTeacher"> - this function takes an object as a parameter that contains info passed from the form. 
        /// </param>
        [HttpPost]
        public void addTeacherData(Teacher newTeacher)
        {

            // Initiate Connection
            MySqlConnection Conn = data.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Create a new command for database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL command
            cmd.CommandText = "INSERT INTO teachers (teacherfname , teacherlname , employeenumber, salary , hiredate) VALUES (@teacherfname , @teacherlname , @employeenumber, @salary , @hiredate)";

            cmd.Parameters.AddWithValue("@teacherfname", newTeacher.teacherfname);
            cmd.Parameters.AddWithValue("@teacherlname", newTeacher.teacherlname);
            cmd.Parameters.AddWithValue("@employeenumber", newTeacher.employeenumber);
            cmd.Parameters.AddWithValue("@salary", newTeacher.salary);
            cmd.Parameters.AddWithValue("@hiredate", newTeacher.hiredate);
            cmd.Prepare(); 

            cmd.ExecuteNonQuery();

            Conn.Close();
        }





        /// <summary>
        /// Looks for a teacher in MySQL Database through its id
        /// </summary>
        /// <param name="id">The teacherid</param>
        /// <returns>Details of teacher with a matching ID. It will return an empty Object if the teacher with given ID is not found in the system.</returns>
        /// <example>api/TeacehrData/FindTeacher/6 -> {Teacher Object}</example>
        /// <example>api/TeacherData/FindTeacher/10 -> {Teacher Object}</example>
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher newTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = data.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers where teacherid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader Result = cmd.ExecuteReader();

            while (Result.Read())
            {
                //Access Column information by the DB column name as an index
                
                int t_id = (int)Result["teacherid"];
                string tFirstName = (string)Result["teacherfname"];
                string tLastName = (string)Result["teacherlname"];
                DateTime hiredate = (DateTime)Result["hiredate"];
                decimal salary = (decimal)Result["salary"];

                newTeacher.teacherid = t_id;
                newTeacher.teacherfname = tFirstName;
                newTeacher.teacherlname = tLastName;
                newTeacher.hiredate = hiredate;
                newTeacher.salary = salary;
            }
            Conn.Close();
             
            return newTeacher;
        }






        /// <summary>
        /// Deletes the record who's id is passed in the parameter
        /// </summary>
        /// <param name="teacherid"> the unique id of the record.</param>
        /// <example>POST /api/TeacherData/deleteTeacher/3</example>

        [HttpPost]

        [Route("api/TeacherData/deleteTeacher/{teacherid}")]
        public void deleteTeacher(int teacherid)
        {

            // Initiate Connection
            MySqlConnection Conn = data.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Create a new command for database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Delete from teachers where teacherid = @teacherid";
            cmd.Parameters.AddWithValue("@teacherid", teacherid);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
            Conn.Close();   
        }
    }
}
