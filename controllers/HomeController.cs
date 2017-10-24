using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace ITWEB_Mandatory5.Home
{
    public class HomeController : Controller
    {
        // 
        // GET: /
        public ViewResult Index()
        {
            return View();
        }
    }
}