using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleMVC.Models;

namespace SampleMVC.Controllers
{
    public class CategoriesController : Controller
    {

        private static List<Category> categories = new List<Category>{
                new Category { categoryID = 1, categoryName ="Confections"},
                new Category { categoryID = 2, categoryName ="Diary Products"},
                new Category { categoryID = 3, categoryName ="Grains/Cereals"},
                new Category { categoryID = 4, categoryName ="Meat/Poultry"},
                new Category { categoryID = 5, categoryName ="Produce"},
                new Category { categoryID = 6, categoryName ="Milk"}
        };
        

        public IActionResult Index()
        {
            List<User> users = new List<User>() {
                new User { userID = 1, username="siti", password="password"},
                new User { userID = 2, username="siti2", password="password2"},
                new User { userID = 3, username="siti3", password="password3"},
            };
            // var model = new Category{
            //     categoryID = 1,
            //     categoryName = "Vegetable"
            // };
            // return View(model);

            ViewData["users"] = users;

            return View(categories);
        }

        public IActionResult Detail(int id)
        {
            ViewData["username"] = "Arya Alkatiri";
            ViewBag.role = "admin";

            var category = (from c in categories where c.categoryID == id select c).SingleOrDefault();
            // var category = categories.SingleOrDefault(c => c.categoryID == id);
            return View(category);
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            // return Content($"Category ID : {category.categoryID} - Category Name : {category.categoryName}");
            categories.Add(category);
            return RedirectToAction("Index");    
        }

        public IActionResult Edit(int id){
            var editCategory = categories.SingleOrDefault(c => c.categoryID == id);
            if(editCategory == null){
                return NotFound();
            }
            return View(editCategory);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if(category == null){
                return BadRequest();
            }
            // return Content($"Category ID : {category.categoryID} - Category Name : {category.categoryName}");
            var editCategory = categories.SingleOrDefault(c => c.categoryID == category.categoryID);
            editCategory.categoryName = category.categoryName;
            
            return RedirectToAction("Index");    
        }

        public IActionResult Delete(int id)
        {
            var deleteCategory = categories.SingleOrDefault(c => c.categoryID == id);

            if (deleteCategory != null)
            {
                categories.Remove(deleteCategory);
                // Save changes or perform additional actions if needed
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            if(string.IsNullOrEmpty(search)){
                return RedirectToAction("Index");
            }
            var searchResults = categories.Where(c => c.categoryName.Contains(search));
            return View("Index", searchResults);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}