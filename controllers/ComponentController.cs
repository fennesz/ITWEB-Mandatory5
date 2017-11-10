using AutoMapper;
using ITWEB_Mandatory5.DAL;
using ITWEB_Mandatory5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ITWEB_Mandatory5.ViewModels.CategoryController;
using System.Collections.Generic;
using ITWEB_Mandatory5.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ITWEB_Mandatory5.Web
{
    public class ComponentController : BaseController
    {
        IRepository<Component> _componentRepo;
        IRepository<ComponentType> _componentTypeRepo;
        IMapper _mapper;

        public ComponentController(IMapper mapper, IRepository<Component> componentRepo, IRepository<ComponentType> componentTypeRepo)
        {
            _componentRepo = componentRepo;
            _componentTypeRepo = componentTypeRepo;
            _mapper = mapper;
        }

        // GET: /Component/
        public ViewResult Index()
        {
            var data = _componentRepo.GetAll();
            var VM = _mapper.Map<IEnumerable<Component>, List<ComponentVM>>(data);
            return View(VM);
        }

        // GET: /Component/Details/:id
        public ViewResult Details(int id)
        {
            var data = _componentRepo.Get(id);
            if(data == null)
            {
                return PageNotFound();
            }

            var VM = _mapper.Map<Component, ComponentVM>(data);
            return View(VM);
        }

        // GET: /Component/Create
        public ViewResult Create()
        {
            List<ComponentType> componentTypes = _componentTypeRepo.GetAll().ToList();
            List<SelectListItem> ComponentTypeSelectListItems = new List<SelectListItem>();
            foreach(var componentType in componentTypes)
            {
                ComponentTypeSelectListItems.Add(new SelectListItem() {Text = componentType.ComponentName, Value = componentType.Id.ToString() });
            }
            
            ViewBag.ComponentTypeList = ComponentTypeSelectListItems;
            var VM = new ComponentVM();
            return View(VM);
        }

        // POST: /Component/Create
        [HttpPost]
        public ViewResult Create(ComponentVM data)
        {
            var model = _mapper.Map<ComponentVM, Component>(data);
            _componentRepo.Insert(model);
            return View(nameof(Details), model.Id);
        }

        // GET: /Component/Edit/:id
        public ViewResult Edit(int id)
        {
            var data = _componentRepo.Get(id);
            if (data == null)
            {
                return PageNotFound();
            }

            var VM = _mapper.Map<Component, ComponentVM>(data);
            return View(VM);
        }

        // POST: /Component/Edit/:id
        [HttpPost]
        public ViewResult Edit(int id, ComponentVM data)
        {
            // Nasty hack because we are dependent on the Entity framework proxy classes in the 
            // Repository.
            var model = _componentRepo.Get(id);
            var dataMapped = _mapper.Map<ComponentVM, Component>(data);

            model.AdminComment = dataMapped.AdminComment;
            model.ComponentNumber = dataMapped.ComponentNumber;
            model.ComponentTypeId = dataMapped.ComponentTypeId;
            model.SerialNo = dataMapped.SerialNo;
            model.Status = dataMapped.Status;
            model.UserComment = dataMapped.UserComment;

            _componentRepo.Update(model);
            return View(nameof(Details), id);
        }

        // POST: /Component/Delete/:id
        [HttpPost]
        public ViewResult Delete(int id, ComponentVM data)
        {
            var model = _mapper.Map<ComponentVM, Component>(data);
            _componentRepo.Delete(model);
            return View(nameof(Index));
        }
    }
}