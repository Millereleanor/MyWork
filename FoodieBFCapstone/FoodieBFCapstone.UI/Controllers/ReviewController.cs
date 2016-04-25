using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodieBFCapstone.Data;
using PagedList;

namespace FoodieBFCapstone.UI.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult ReviewSubCategory(string subcategory, int? page)
        {
            var repo = new BlogPostRepository();

            var activeBlogPost = repo.GetActivePostsinSubCategory(subcategory);

            foreach (var post in activeBlogPost)
            {
                post.Author = repo.GetAuthorUserNameByBlogId(post.BlogId);
            }
            var pageNumber = page ?? 1;
            var onePageOfProducts = activeBlogPost.ToPagedList(pageNumber, 5);

            ViewBag.OnePageOfProducts = onePageOfProducts;
            ViewBag.subcategory = subcategory;

            return View(activeBlogPost);
        }
        
    }
}