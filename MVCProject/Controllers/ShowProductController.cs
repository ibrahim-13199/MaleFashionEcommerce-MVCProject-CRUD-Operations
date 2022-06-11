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
    public class ShowProductController : Controller
    {
         IproductRepository productRepository;
         IcategoryRepository categoryRepository;

        

        public ShowProductController(IproductRepository productRepo,IcategoryRepository categoryRepo)
        {
            productRepository=productRepo;
            categoryRepository=categoryRepo;
         
        }
        public IActionResult Index()
        {
            List<Product> productList = productRepository.GetAll();
            return View("Index",productList);
        }

        public IActionResult Details(int id)
        {
            Product product1 = productRepository.FindById(id); 
            return View("Details", product1);
        }

           

        public IActionResult New()
        {
            List<Category> categoryList = categoryRepository.GetAll();// 
            ViewData["CategoryList"] = categoryList;
            //return View();
            return View(new Product());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult SaveNew(Product product1)
        {
            // if (newStd.Name != null&&newStd.Address!=null&)
            if (ModelState.IsValid == true)
            {
                try
                {
                    productRepository.insert(product1);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    
                    ModelState.AddModelError("CategoryId", "Select Category");
                    ModelState.AddModelError("Exception", ex.InnerException.Message);
                }
            }
            List<Category> categoryList = categoryRepository.GetAll();
            ViewData["CategoryList"] = categoryList;
            return View("New", product1);
        }

        public IActionResult Edit(int id)
        {
            Product product1 = productRepository.FindById(id); 
            if (product1 != null)
            {
                ViewData["categoryList"] = categoryRepository.GetAll(); 
                return View("Edit", product1);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SaveEdit(int id,Product product1)
        {
            if (product1.tilte != null)
            {
                productRepository.Edit(id, product1);
                return RedirectToAction("Index");
            }
            ViewData["categoryList"] = categoryRepository.GetAll(); 
            return View("Edit", product1);
        }


      public IActionResult deleteproduct(int id)
        {
             productRepository.Delete(id);
            return RedirectToAction("Index");
        }







    }
}

