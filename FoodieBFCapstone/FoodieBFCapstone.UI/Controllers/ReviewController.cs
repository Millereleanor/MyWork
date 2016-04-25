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

            var activeBlogPost = repo.GetActivePostsinSubCategory(subcategory);

            foreach (var post in activeBlogPost)
            {
                post.Author = repo.GetAuthorUserNameByBlogId(post.BlogId);
            }

            return View(activeBlogPost);
        }
        
    }
}