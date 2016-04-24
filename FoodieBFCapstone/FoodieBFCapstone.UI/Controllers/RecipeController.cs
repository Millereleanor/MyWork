using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodieBFCapstone.Data;
using FoodieBFCapstone.Models;

namespace FoodieBFCapstone.UI.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Breakfast()
        {
            var repo = new BlogPostRepository();
            var blogPost = repo.GetBySubcategory("Breakfast");

            return View();
        }

        public ActionResult Lunch()
        {
            return View();
        }

        public ActionResult Dinner()
        {
            return View();
        }

        public ActionResult Dessert()
        {
            return View();
        }

        public ActionResult Drink()
        {
            return View();
        }
    }
}