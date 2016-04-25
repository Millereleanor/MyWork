using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodieBFCapstone.Data;

namespace FoodieBFCapstone.UI.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult ReviewSubCategory(string subcategory)
        {
            var repo = new BlogPostRepository();
            var blogPost = repo.GetBySubcategory(subcategory);

            return View(blogPost);
        }
        
    }
}