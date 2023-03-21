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
    public class StudentDataController : ApiController
    {
        private SchoolDbContext data = new SchoolDbContext();

        [HttpGet]
        public IEnumerable<Students> listStudents()
        {
            // Initiate Connection
            MySqlConnection Conn = data.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Create a new command for database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL command
            cmd.CommandText = "Select * from Students";


            MySqlDataReader Result = cmd.ExecuteReader();

            List<Students> student = new List<Students>();

            //Loop Through Each Row the Result Set
            while (Result.Read())
            {
                //Access Column information by the DB column name as an index

                int s_id = (int)Result["studentid"];
                string sFirstName = (string)Result["studentfname"];
                string sLastName = (string)Result["studentlname"];
                string studentnumber = (string)Result["studentnumber"];
            

                Students newStudent = new Students();
                newStudent.studentid = s_id;
                newStudent.studentfname = sFirstName;
                newStudent.studentlname = sLastName;
                newStudent.studentnumber = studentnumber;
                

                //Add the Author Name to the List

                student.Add(newStudent);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return student;
        }





//        [HttpGet]
  //      public IEnumerable<Classes> showStudents(int id)
      //  {
    //        return "";
        //}

    }
}
