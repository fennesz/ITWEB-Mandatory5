using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace ITWEB_Mandatory5.Web
{
    public class ComponentCategoryController : Controller
    {
        // 
        // GET: /ComponentCategory/
        public ViewResult Index()
        {
            return View();
        }

        // 
        // GET: /ComponentCategory/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}