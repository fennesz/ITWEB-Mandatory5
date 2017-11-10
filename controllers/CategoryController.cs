using AutoMapper;
using ITWEB_Mandatory5.DAL;
using ITWEB_Mandatory5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ITWEB_Mandatory5.ViewModels.CategoryController;
using System.Collections.Generic;
using ITWEB_Mandatory5.ViewModels;

namespace ITWEB_Mandatory5.Web
{
    public class CategoryController : BaseController
    {
        IRepository<Category> _repo;
        IMapper _mapper;

        public CategoryController(IMapper mapper, IRepository<Category> repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: /Category/
        public ViewResult Index()
        {
            var data = _repo.GetAll();
            var VM = _mapper.Map<IEnumerable<Category>, List<CategoryVM>>(data);
            return View(VM);
        }

        // GET: /Category/Details/:id
        public ViewResult Details(int id)
        {
            var data = _repo.Get(id);
            if(data == null)
            {
                return PageNotFound();
            }

            var VM = _mapper.Map<Category, CategoryVM>(data);
            return View(VM);
        }

        // GET: /Category/Create
        public ViewResult Create()
        {
            var VM = new CategoryVM();
            return View(VM);
        }

        // POST: /Category/Create
        [HttpPost]
        public ViewResult Create(CategoryVM data)
        {
            var model = _mapper.Map<CategoryVM, Category>(data);
            _repo.Insert(model);
            return View(nameof(Details), model.Id);
        }

        // GET: /Category/Edit/:id
        public ViewResult Edit(int id)
        {
            var data = _repo.Get(id);
            if (data == null)
            {
                return PageNotFound();
            }

            var VM = _mapper.Map<Category, CategoryVM>(data);
            return View(VM);
        }

        // POST: /Category/Edit/:id
        [HttpPost]
        public ViewResult Edit(int id, CategoryVM data)
        {
            // Nasty hack because we are dependent on the Entity framework proxy classes in the 
            // Repository.
            var model = _repo.Get(id);
            var dataMapped = _mapper.Map<CategoryVM, Category>(data);
            model.Name = dataMapped.Name;

            _repo.Update(model);
            return View(nameof(Details), id);
        }

        // POST: /Category/Delete/:id
        [HttpPost]
        public ViewResult Delete(int id, CategoryVM data)
        {
            var model = _mapper.Map<CategoryVM, Category>(data);
            _repo.Delete(model);
            return View(nameof(Index));
        }
    }
}