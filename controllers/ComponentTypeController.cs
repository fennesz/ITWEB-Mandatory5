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
    public class ComponentTypeController : BaseController
    {
        IRepository<Component> _componentRepo;
        IRepository<ComponentType> _componentTypeRepo;
        IRepository<Category> _categoryRepo;
        IMapper _mapper;

        public ComponentTypeController(
            IMapper mapper, 
            IRepository<Component> componentRepo,
            IRepository<ComponentType> componentTypeRepo,
            IRepository<Category> categoryRepo
            )
        {
            _componentRepo = componentRepo;
            _componentTypeRepo = componentTypeRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        // GET: /ComponentType/
        public ViewResult Index()
        {
            var data = _componentTypeRepo.GetAll();
            var VM = _mapper.Map<IEnumerable<ComponentType>, List<ComponentTypeVM>>(data);
            return View(VM);
        }

        // GET: /ComponentType/Create
        public ViewResult Create()
        {
            ViewBag.CategoryList = CategorySelectList();
            ViewBag.ComponentTypeList = ComponentTypesSelectList();
            ViewBag.ComponentTypeStatusList = ComponentTypeStatusEnumSelectList();
            var VM = new ComponentTypeCreateVM();
            return View(VM);
        }

        // POST: /ComponentType/Create
        [HttpPost]
        public ActionResult Create(ComponentTypeCreateVM data)
        {
            var model = _mapper.Map<ComponentTypeCreateVM, ComponentType>(data);
            _componentTypeRepo.Insert(model);
            return RedirectToAction(nameof(Index), "ComponentType");
        }

        // GET: /ComponentType/Edit/:id
        public ViewResult Edit(int id)
        {
            ViewBag.CategoryList = CategorySelectList();
            ViewBag.ComponentTypeList = ComponentTypesSelectList();
            ViewBag.ComponentTypeStatusList = ComponentTypeStatusEnumSelectList();
            var data = _componentTypeRepo.Get(id);
            if (data == null)
            {
                return PageNotFound();
            }

            var VM = _mapper.Map<ComponentType, ComponentTypeCreateVM>(data);
            return View(VM);
        }

        // POST: /ComponentType/Edit/:id
        [HttpPost]
        public ActionResult Edit(int id, ComponentTypeCreateVM data)
        {
            // Nasty hack because we are dependent on the Entity framework proxy classes in the 
            // Repository.
            var model = _componentTypeRepo.Get(id);
            var dataMapped = _mapper.Map<ComponentTypeCreateVM, ComponentType>(data);

            model.AdminComment = dataMapped.AdminComment;
            model.ComponentInfo = dataMapped.ComponentInfo;
            model.ComponentName = dataMapped.ComponentName;
            model.Datasheet = dataMapped.Datasheet;
            model.Image = dataMapped.Image;
            model.ImageUrl= dataMapped.ImageUrl;
            model.Location = dataMapped.Location;
            model.Manufacturer = dataMapped.Manufacturer;
            model.Status = dataMapped.Status;
            model.WikiLink = dataMapped.WikiLink;
            
            // Eeeeewww
            model.ComponentTypeCategory.Clear();
            _componentTypeRepo.Update(model);
            foreach (var ctc in dataMapped.ComponentTypeCategory)
            {
                model.ComponentTypeCategory.Add(ctc);
            }
            // Eeeeewww

            _componentTypeRepo.Update(model);
            return RedirectToAction(nameof(Index), "ComponentType");
        }

        // POST: /ComponentType/Delete/:id
        public ActionResult Delete(int id)
        {
            _componentTypeRepo.Delete(_componentTypeRepo.Get(id));
            return RedirectToAction(nameof(Index), "ComponentType");
        }

        // GET: /ComponentType/Category/:id
        public ActionResult Category(int id)
        {
            var category = _categoryRepo.Find(cat => cat.Id == id).First();
            var data = _componentTypeRepo.Find((ct) => ct.ComponentTypeCategory.Any((ctc) => ctc.CategoryId == id));
            var VM = _mapper.Map<IEnumerable<ComponentType>, List<ComponentTypeVM>>(data);
            ViewBag.CategoryName = category.Name;
            return View(VM);
        }

        List<SelectListItem> ComponentTypeStatusEnumSelectList()
        {
            var itemsOfList = new List<SelectListItem>();
            var EnumStrings = Enum.GetNames(typeof(ComponentTypeStatus));
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

        List<SelectListItem> CategorySelectList()
        {
            List<Category> categories = _categoryRepo.GetAll().ToList();
            List<SelectListItem> categorySelectListItems = new List<SelectListItem>();
            foreach (var category in categories)
            {
                categorySelectListItems.Add(new SelectListItem() { Text = category.Name, Value = category.Id.ToString() });
            }
            return categorySelectListItems;
        }
    }
}