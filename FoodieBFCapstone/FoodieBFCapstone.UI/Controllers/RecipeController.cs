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
        public ActionResult RecipeSubCategory(string subcategory)
        {
            var repo = new BlogPostRepository();
            var blogPost = repo.GetBySubcategory(subcategory);

            return View(blogPost);
        }

        
    }
}