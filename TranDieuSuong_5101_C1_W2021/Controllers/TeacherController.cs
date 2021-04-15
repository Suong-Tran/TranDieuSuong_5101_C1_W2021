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

    ////GET : /Author/Ajax_New
    //public ActionResult Ajax_New()
    //{
    //  return View();

    //}

    //POST : /Author/Create
    [HttpPost]
    public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, decimal Salary)
    {
      //Identify that this method is running
      //Identify the inputs provided from the form

      if (string.IsNullOrEmpty(TeacherFname))
      {
        Debug.WriteLine("No no");
      }

      Teacher NewTeacher = new Teacher();
      NewTeacher.TeacherFname = TeacherFname;
      NewTeacher.TeacherLname = TeacherLname;
      NewTeacher.EmployeeNumber = EmployeeNumber;
      NewTeacher.Salary = Salary;

      TeacherDataController controller = new TeacherDataController();
      controller.AddTeacher(NewTeacher);

      return RedirectToAction("List");
    }

  }

}

