using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;


namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            //return list of all the cheese categories
            List<CheeseCategory> cheeseCategories = context.Categories.ToList();

            return View(cheeseCategories);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new category to my existing categories
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = addCategoryViewModel.Name, 
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }
    }
}