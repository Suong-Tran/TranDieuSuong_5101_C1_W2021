using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogProject.Models;
using MySql.Data.MySqlClient;
using TranDieuSuong_5101_C1_W2021.Models;

namespace TranDieuSuong_5101_C1_W2021.Controllers
{
    public class TeacherDataController : ApiController
    {
      private SchoolDbContext School = new SchoolDbContext();

    /// <summary>
    /// this will return a list of teacher and their information
    /// </summary>
    /// <example>GET api/TeacherData/ListTeachers</example>
    /// <returns>
    ///   a list of author with some of their information
    /// </returns>
    [HttpGet]
      public IEnumerable<Teacher> ListTeachers()
      {
        MySqlConnection Conn = School.AccessDatabase();

        Conn.Open();

        MySqlCommand cmd = Conn.CreateCommand();

        cmd.CommandText = "Select * from Teachers";

        MySqlDataReader ResultSet = cmd.ExecuteReader();

        List<Teacher> Teachers = new List<Teacher> { };

        while (ResultSet.Read())
        {
            //Access Column information by the DB column name as an index
            int TeacherId = (int)ResultSet["teacherid"];
            string TeacherFname = ResultSet["teacherfname"].ToString();
            string TeacherLname = ResultSet["teacherlname"].ToString();
            string EmployeeNumber = ResultSet["employeenumber"].ToString();
            DateTime HireDate = Convert.ToDateTime(ResultSet["hiredate"].ToString());
            decimal Salary = (decimal)ResultSet["salary"];


            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherId = TeacherId;
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.HireDate = HireDate;
            NewTeacher.Salary = Salary;
          

            //Add the Author Name to the List
            Teachers.Add(NewTeacher);
          }
        Conn.Close();

        return Teachers;
      }

      /// <summary>
      /// Search for a teacher with a given id
      /// </summary>
      /// <param name="id">teacher id</param>
      /// <returns>an object with information of said teacher information</returns>
      [HttpGet]
      public Teacher FindTeacher(int id)
      {
        Teacher NewTeacher = new Teacher();

        MySqlConnection Conn = School.AccessDatabase();

        Conn.Open();

        MySqlCommand cmd = Conn.CreateCommand();

        cmd.CommandText = "Select * from Teachers where teacherid = " + id;

        //Gather Result Set of Query into a variable
        MySqlDataReader ResultSet = cmd.ExecuteReader();

        while (ResultSet.Read())
        {
          //Access Column information by the DB column name as an index
          int TeacherId = (int)ResultSet["teacherid"];
          string TeacherFname = ResultSet["teacherfname"].ToString();
          string TeacherLname = ResultSet["teacherlname"].ToString();
          string EmployeeNumber = ResultSet["employeenumber"].ToString();
          DateTime HireDate = Convert.ToDateTime(ResultSet["hiredate"].ToString());
          decimal Salary = (decimal)ResultSet["salary"];

          NewTeacher.TeacherId = TeacherId;
          NewTeacher.TeacherFname = TeacherFname;
          NewTeacher.TeacherLname = TeacherLname;
          NewTeacher.EmployeeNumber = EmployeeNumber;
          NewTeacher.HireDate = HireDate;
          NewTeacher.Salary = Salary;
        }


        return NewTeacher;
      }

  }
}
