using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProject.Models;
using TranDieuSuong_5101_C1_W2021.Models;
using System.Diagnostics;


namespace TranDieuSuong_5101_C1_W2021.Controllers
{
  public class TeacherController : Controller
  {
    // GET: Teacher
    public ActionResult Index()
    {
      return View();
    }

    //GET : /Teacher/List
    public ActionResult List(string SearchKey = null)
    {
      TeacherDataController controller = new TeacherDataController();
      IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
      return View(Teachers);
    }

    //GET : /Teacher/Show/{id}
    public ActionResult Show(int id)
    {
      TeacherDataController controller = new TeacherDataController();
      Teacher NewTeacher = controller.FindTeacher(id);


      return View(NewTeacher);
    }

    //GET : /Teacher/DeleteConfirm/{id}
    public ActionResult DeleteConfirm(int id)
    {
      TeacherDataController controller = new TeacherDataController();
      Teacher NewTeacher = controller.FindTeacher(id);


      return View(NewTeacher);
    }


    //POST : /Teacher/Delete/{id}
    [HttpPost]
    public ActionResult Delete(int id)
    {
      TeacherDataController controller = new TeacherDataController();
      controller.DeleteTeacher(id);
      return RedirectToAction("List");
    }

    //GET : /Teacher/New
    public ActionResult New()
    {
      return View();
    }


    //GET : /Author/Ajax_New
    public ActionResult Ajax_New()
    {
      return View();

    }

    //POST : /Author/Create
    [HttpPost]
    public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, decimal Salary)
    {
      //Identify that this method is running
      //Identify the inputs provided from the form

      Teacher NewTeacher = new Teacher();
      NewTeacher.TeacherFname = TeacherFname;
      NewTeacher.TeacherLname = TeacherLname;
      NewTeacher.EmployeeNumber = EmployeeNumber;
      NewTeacher.Salary = Salary;

      TeacherDataController controller = new TeacherDataController();
      controller.AddTeacher(NewTeacher);

      return RedirectToAction("List");
    }

    /// <summary>
    /// Go to the dynamic page "Update Teacher" then gather info from the database
    /// </summary>
    /// <param name="id">Id of the teacher</param>
    /// <returns>provides the current information of the teacher and asks the user to alter the information as part of a form.</returns>
    /// <example>GET : /Teacher/Update/5</example>
    public ActionResult Update(int id)
    {
      TeacherDataController controller = new TeacherDataController();
      Teacher SelectedTeacher = controller.FindTeacher(id);

      return View(SelectedTeacher);
    }

    public ActionResult Ajax_Update(int id)
    {
      TeacherDataController controller = new TeacherDataController();
      Teacher SelectedTeacher = controller.FindTeacher(id);

      return View(SelectedTeacher);
    }

    /// <summary>
    /// Conveys the newly altered information receiving from the post request to the API,
    /// and redirects to the "Author Show" page of the updated teacher.
    /// </summary>
    /// <param name="id">teacher id</param>
    /// <param name="TeacherFname">teacher first name</param>
    /// <param name="TeacherLname">teacher last name</param>
    /// <param name="EmployeeNumber">teacher employee number</param>
    /// <param name="HireDate">teacher date of hiring</param>
    /// <param name="Salary">teacher salary</param>
    /// <returns>a page with info about the current teacher</returns>
    [HttpPost]
    public ActionResult Update(int id, string TeacherFname, string TeacherLname, string EmployeeNumber, string HireDate, decimal Salary)
    {
      if (string.IsNullOrEmpty(TeacherFname))
      {
        Debug.WriteLine("No no");
      }
      Teacher TeacherInfo = new Teacher();
      TeacherInfo.TeacherFname = TeacherFname;
      TeacherInfo.TeacherLname = TeacherLname;
      TeacherInfo.EmployeeNumber = EmployeeNumber;
      TeacherInfo.HireDate = Convert.ToDateTime(HireDate);
      TeacherInfo.Salary = Salary;

      TeacherDataController controller = new TeacherDataController();
      controller.UpdateTeacher(id, TeacherInfo);

      return RedirectToAction("Show/" + id);
    }

  }
}

