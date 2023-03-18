﻿using Assign3C1.Models;
using MySql.Data.MySqlClient;
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

        [HttpGet]
        public IEnumerable<Teachers> teachersList()
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

            List<Teachers> Teacher = new List<Teachers>();

            //Loop Through Each Row the Result Set
            while (Result.Read())
            {
                //Access Column information by the DB column name as an index

                int t_id = (int)Result["teacherid"];
                string tFirstName = (string)Result["teacherfname"];
                string tLastName = (string)Result["teacherlname"];
                DateTime hiredate = (DateTime)Result["hiredate"];
                decimal salary = (decimal)Result["salary"];

                Teachers newTeacher = new Teachers();
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

        [HttpGet]
        public Teachers showTeacher(int id)
        {
            Teachers newTeacher = new Teachers();
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
                string employeenumber =(string)Result["employeenumber"];
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
    }
}