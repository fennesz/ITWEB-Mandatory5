using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using ITWEB_Mandatory5.DAL;
using System.Diagnostics;
using ITWEB_Mandatory5.Models;
using System.Linq;

namespace ITWEB_Mandatory5.Web
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Component> _componentRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<ComponentType> _componentTypeRepo;

        public HomeController(IMapper mapper, IRepository<Component> componentRepo, IRepository<Category> categoryRepo, IRepository<ComponentType> componentTypeRepo)
        {
            _mapper = mapper;
            _componentRepo = componentRepo;
            _categoryRepo = categoryRepo;
            _componentTypeRepo = componentTypeRepo;
        }

        // GET: /
        public ViewResult Index()
        {
            IEnumerable<Component> model=_componentRepo.GetAll();
            Console.WriteLine(model);
            return View(model);
        }
    }
}