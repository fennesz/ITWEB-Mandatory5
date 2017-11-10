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

        // GET: /ComponentCategory/
        public ViewResult Index()
        {
            var data = _repo.GetAll();
            var VM = _mapper.Map<IEnumerable<Category>, List<CategoryVM>>(data);
            return View(VM);
        }

        // GET: /ComponentCategory/Details/:id
        public ViewResult Details(int id)
        {
            var data = _repo.Get(id);
            if(data == null)
            {
                return PageNotFound();
            }

            var VM = _mapper.Map<Category, CategoryDetailsViewmodel>(data);
            return View(VM);
        }

        // GET: /ComponentCategory/Create
        public ViewResult Create()
        {
            var VM = new CategoryCreateViewmodel();
            return View(VM);
        }

        // POST: /ComponentCategory/Create
        [HttpPost]
        public ViewResult Create(CategoryCreateViewmodel data)
        {
            var model = _mapper.Map<CategoryCreateViewmodel, Category>(data);
            _repo.Insert(model);
            return View(nameof(Details), model.Id);
        }

        // GET: /ComponentCategory/Edit/:id
        public ViewResult Edit(int id)
        {
            var data = _repo.Get(id);
            if (data == null)
            {
                return PageNotFound();
            }

            var VM = _mapper.Map<Category, CategoryDetailsViewmodel>(data);
            return View(VM);
        }

        // POST: /ComponentCategory/Edit/:id
        [HttpPost]
        public ViewResult Edit(int id, CategoryEditViewmodel data)
        {
            var model = _mapper.Map<CategoryEditViewmodel, Category>(data);
            _repo.Update(model);
            return View(nameof(Details), id);
        }

        // POST: /ComponentCategory/Delete/:id
        [HttpPost]
        public ViewResult Delete(int id, CategoryDeleteViewmodel data)
        {
            var model = _mapper.Map<CategoryDeleteViewmodel, Category>(data);
            _repo.Delete(model);
            return View(nameof(Index));
        }
    }
}