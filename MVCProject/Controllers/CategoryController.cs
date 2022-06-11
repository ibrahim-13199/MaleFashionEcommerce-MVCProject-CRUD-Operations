using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;


using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace MVCProject.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        IproductRepository productRepository;
        IcategoryRepository categoryRepository;



        public CategoryController(IproductRepository productRepo, IcategoryRepository categoryRepo)
        {
            productRepository = productRepo;
            categoryRepository = categoryRepo;

        }
        public IActionResult Index()
        {
            List<Category> categoryList = categoryRepository.GetAll();
            return View("Index", categoryList);
          
        }
        public IActionResult Details(int id)
        {
            Category category1 = categoryRepository.FindById(id);
            return View("Details", category1);
        }
        public IActionResult New()
        {
            List<Category> categoryList = categoryRepository.GetAll();
            
           
            return View(new Category());
        }

        public IActionResult SaveNew(Category category1)
        {
            
            if (ModelState.IsValid == true)
            {
                categoryRepository.insert(category1);
                return RedirectToAction("Index");
            }
         
            return View("New", category1);
        }

        public IActionResult Edit(int id)
        {
            Category category1 = categoryRepository.FindById(id);
            if (category1 != null)
            {
                categoryRepository.Edit(id,category1);
                return View(category1);

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SaveEdit(int id, Category category1)
        {
            if (category1.name != null)
            {
                categoryRepository.Edit(id, category1);
                return RedirectToAction("Index");
            }
           
            return View("Edit", category1);
        }


        public IActionResult deleteCategory(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }



    }
}
