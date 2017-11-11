using AutoMapper;
using ITWEB_Mandatory5.DAL;
using ITWEB_Mandatory5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ITWEB_Mandatory5.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System;

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

        // GET: /Component/Create
        public ViewResult Create()
        {
            ViewBag.ComponentTypeList = ComponentTypesSelectList();
            ViewBag.ComponentStatusList = ComponentStatusEnumSelectList();
            var VM = new ComponentVM();
            return View(VM);
        }

        // POST: /Component/Create
        [HttpPost]
        public ActionResult Create(ComponentVM data)
        {
            var model = _mapper.Map<ComponentVM, Component>(data);
            _componentRepo.Insert(model);
            return RedirectToAction(nameof(Index), "Component");
        }

        // GET: /Component/Edit/:id
        public ViewResult Edit(int id)
        {
            ViewBag.ComponentTypeList = ComponentTypesSelectList();
            ViewBag.ComponentStatusList = ComponentStatusEnumSelectList();
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
        public ActionResult Edit(int id, ComponentVM data)
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
            return RedirectToAction(nameof(Index), "Component");
        }

        // POST: /Component/Delete/:id
        public ActionResult Delete(int id)
        {
            _componentRepo.Delete(_componentRepo.Get(id));
            return RedirectToAction(nameof(Index), "Component");
        }

        // GET: /Component/ComponentType/:id
        public ActionResult ComponentType(int id)
        {
            var componentType = _componentTypeRepo.Find(ct => ct.Id == id).First();
            var data = _componentRepo.Find((c) => c.ComponentType.Id == id);
            var VM = _mapper.Map<IEnumerable<Component>, List<ComponentVM>>(data);
            ViewBag.ComponentTypeName = componentType.ComponentName;
            return View(VM);
        }

        List<SelectListItem> ComponentStatusEnumSelectList()
        {
            var itemsOfList = new List<SelectListItem>();
            var EnumStrings = Enum.GetNames(typeof(ComponentStatus));
            foreach (var enumString in EnumStrings)
            {
                itemsOfList.Add(new SelectListItem() { Text = enumString, Value = enumString });
            }

            return itemsOfList;
        }

        List<SelectListItem> ComponentTypesSelectList()
        {
            List<ComponentType> componentTypes = _componentTypeRepo.GetAll().ToList();
            List<SelectListItem> ComponentTypeSelectListItems = new List<SelectListItem>();
            foreach (var componentType in componentTypes)
            {
                ComponentTypeSelectListItems.Add(new SelectListItem() { Text = componentType.ComponentName, Value = componentType.Id.ToString() });
            }
            return ComponentTypeSelectListItems;
        }
    }
}