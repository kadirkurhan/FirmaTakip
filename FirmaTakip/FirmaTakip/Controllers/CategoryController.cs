using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirmaTakip.Entities;
using FirmaTakip.Interfaces;
using FirmaTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirmaTakip.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }
        public IActionResult Delete(int id)
        {
            _categoryRepository.Delete(new Category { Id = id });
            return RedirectToAction("index");
        }
        public IActionResult CreateCategory()
        {

            return View(new AddCategoryModel());
        }
        [HttpPost]
        public IActionResult CreateCategory(AddCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                AddCategoryModel category = new AddCategoryModel();

                _categoryRepository.Add(new Category{
                    Id = model.Id,
                    Name = model.Name
                });
                
                

                
                return RedirectToAction("index", "category");
            }
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var category = _categoryRepository.GetwithId(id);

            UpdateCategoryModel guncellenecekVeri = new UpdateCategoryModel
            {
                Id = category.Id,
                Name = category.Name
                

            };
            return View(guncellenecekVeri);
        }


        [HttpPost]
        public IActionResult Update(UpdateCategoryModel model)
        {

            if (ModelState.IsValid)
            {
                var company = _categoryRepository.GetwithId(model.Id);


                company.Id = model.Id;
                company.Name = model.Name;
                


                _categoryRepository.Update(company);
                return RedirectToAction("index", "category");

            }


            return View(model);

        }



    }
}