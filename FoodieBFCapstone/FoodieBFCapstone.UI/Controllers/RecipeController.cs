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

            var activeBlogPost = repo.GetActivePostsinSubCategory(subcategory);

            foreach (var post in activeBlogPost)
            {
                post.Author = repo.GetAuthorUserNameByBlogId(post.BlogId);
            }
            
            return View(activeBlogPost);
        }

        
    }
}