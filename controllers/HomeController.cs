using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Encodings.Web;

using ITWEB_Mandatory5.DAL;
using System.Diagnostics;

namespace ITWEB_Mandatory5.Web
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: /
        public ViewResult Index()
        {
            return View();
        }
    }
}