using Lab2.Dao;
using Lab2.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var view =  View("View/index.cshtml");
            ViewModel model = new ViewModel();
            var categories = CategoryContext.GetCategories();
            model.Categories = categories;
            model.Products = ProductContext.GetProducts(categories.First<Category>().ID);
            view.ViewData.Model = model;
            return view;
        }
        public IActionResult Select()
        {
            return View();
        }
    }
}
