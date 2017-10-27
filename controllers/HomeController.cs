using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Encodings.Web;
using ITWEB_Mandatory5.DAL;
using System.Diagnostics;
using ITWEB_Mandatory5.Models;

namespace ITWEB_Mandatory5.Web
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Models.Component> _componentRepo;
        private readonly IRepository<Models.Category> _categoryRepo;

        public HomeController(IMapper mapper, IRepository<Component> componentRepo, IRepository<Category> categoryRepo)
        {
            _mapper = mapper;
            _componentRepo = componentRepo;
            _categoryRepo = categoryRepo;
        }

        // GET: /
        public ViewResult Index()
        {
            return View();
        }
    }
}