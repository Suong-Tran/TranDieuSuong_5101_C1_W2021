using System.Web;
using System.Web.Mvc;

namespace TranDieuSuong_5101_C1_W2021
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
