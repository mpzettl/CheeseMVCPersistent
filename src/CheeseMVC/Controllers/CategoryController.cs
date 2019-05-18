using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;
using CheeseMVC.Data;
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
            List<CheeseCategory> categories = context.Categories.ToList();

            return View(categories);
        }
    }
}