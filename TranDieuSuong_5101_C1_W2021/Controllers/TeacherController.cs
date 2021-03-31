using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProject.Models;
using TranDieuSuong_5101_C1_W2021.Models;

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

  }
}
