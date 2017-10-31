using AutoMapper;
using ITWEB_Mandatory5.DAL;
using ITWEB_Mandatory5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ITWEB_Mandatory5.ViewModels.CategoryController;
using System.Collections.Generic;

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
            var VM = _mapper.Map<IEnumerable<Category>, CategoryIndexViewmodel>(data);
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
    }
}