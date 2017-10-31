using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.Web
{
    public class BaseController : Controller
    {
        protected ViewResult PageNotFound()
        {
            Response.StatusCode = 404;
            return View("PageNotFound");
        }
    }
}
