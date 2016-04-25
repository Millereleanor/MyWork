using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using FoodieBFCapstone.Data;
using FoodieBFCapstone.Models;
using FoodieBFCapstone.UI.Models;
using PagedList;

namespace FoodieBFCapstone.UI.Controllers
{
    public class ContributorController : Controller
    {
        [Authorize(Roles = "Contributor")]
        public ActionResult Index(int? page)
        {
            BlogPostRepository repo = new BlogPostRepository();
            ContributorVM vm = new ContributorVM();
            vm.BlogPosts.AddRange(repo.GetByUserId(User.Identity.GetUserId()));

            var pageNumber = page ?? 1;
            var onePageOfProducts = vm.BlogPosts.ToPagedList(pageNumber, 6);

            ViewBag.OnePageOfProducts = onePageOfProducts;

            return View();
        }

        //[Authorize(Roles = "Contributor")]
        //public ActionResult CreateNewBlog()
        //{
        //    return View();
        //}

        [Authorize(Roles = "Contributor")]
        public ActionResult UpdateBlog(int blogId)
        {
            BlogPostRepository repo = new BlogPostRepository();
            var blogPost = repo.GetById(blogId);

            return View(blogPost);
        }

        [Authorize(Roles = "Contributor")]
        public ActionResult DeactivateBlog(int blogId)
        {
            BlogPostRepository repo = new BlogPostRepository();
            repo.UpdateStatusByBlogId(blogId, Status.Inactive);
            return RedirectToAction("Index", "Contributor");
        }

        [Authorize(Roles = "Contributor")]
        public ActionResult FilterBlogsByStatus(int? page, Status status)
        {
            BlogPostRepository repo = new BlogPostRepository();

            return View();
        }
    }

}