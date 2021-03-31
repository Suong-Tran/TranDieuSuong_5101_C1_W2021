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
    /// this will take a name from the user and return a list of teacher and their information 
    /// if no specific input, it will return a full list of teacher
    /// </summary>
    /// <example>GET api/TeacherData/ListTeachers/Chan</example>
    /// <returns>
    ///   a list of teacher with the name Chan and some of their information
    /// </returns>
    [HttpGet]
    [Route("api/AuthorData/ListTeachers/{SearchKey?}")]
    public IEnumerable<Teacher> ListTeachers(string SearchKey = null)
      {
        MySqlConnection Conn = School.AccessDatabase();

        Conn.Open();

        MySqlCommand cmd = Conn.CreateCommand();

        cmd.CommandText = "Select *,classcode,classname from Teachers join classes on teachers.teacherid = classes.teacherid " +
        "where lower(teacherfname) like lower(@key) or lower(teacherlname) like lower(@key) " +
        "or lower(concat(teacherfname, ' ', teacherlname)) like lower(@key)";

        cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
        cmd.Prepare();

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
            string ClassCode = ResultSet["classcode"].ToString();
            string ClassName = ResultSet["classname"].ToString();


            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherId = TeacherId;
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.HireDate = HireDate;
            NewTeacher.Salary = Salary;
            NewTeacher.ClassCode = ClassCode;
            NewTeacher.ClassName = ClassName;


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

        cmd.CommandText = "Select *,classcode,classname from Teachers join classes on teachers.teacherid = classes.teacherid where teachers.teacherid = " + id;

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
          string ClassCode = ResultSet["classcode"].ToString();
          string ClassName = ResultSet["classname"].ToString();

          NewTeacher.TeacherId = TeacherId;
          NewTeacher.TeacherFname = TeacherFname;
          NewTeacher.TeacherLname = TeacherLname;
          NewTeacher.EmployeeNumber = EmployeeNumber;
          NewTeacher.HireDate = HireDate;
          NewTeacher.Salary = Salary;
          NewTeacher.ClassCode = ClassCode;
          NewTeacher.ClassName = ClassName;
        }


        return NewTeacher;
      }

  }
}
