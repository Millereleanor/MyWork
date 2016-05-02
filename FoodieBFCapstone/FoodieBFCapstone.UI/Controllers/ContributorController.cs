using FoodieBFCapstone.BLL;
using FoodieBFCapstone.Data;
using FoodieBFCapstone.Models;
using FoodieBFCapstone.UI.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            return View(vm);
        }

        public ActionResult CreateNewBlog()
        {
            var vm = new CreatePostVM();
            vm.NewBlog.UserId = new Guid(User.Identity.GetUserId());
            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateNewBlog(CreatePostVM model)
        {
            if (ModelState.IsValid)
            {
                var repo = new BlogPostRepository();
                BlogPostOperations ops = new BlogPostOperations();
                model.NewBlog.Tags = ops.FormatBlogTagsToList(model.TagString);

                repo.WriteBlogTags(model.NewBlog.Tags, model.NewBlog.BlogId);
                repo.WriteBlogPost(model.NewBlog);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [Authorize(Roles = "Contributor")]
        public ActionResult UpdateBlog(int blogId)
        {
            BlogPostRepository repo = new BlogPostRepository();
            CreatePostVM vm = new CreatePostVM();
            vm.NewBlog = repo.GetById(blogId);

            BlogPostOperations ops = new BlogPostOperations();
            vm.TagString = ops.FormatBlogTagsToString(blogId);

            return View(vm);
        }

        [HttpPost]
        public ActionResult UpdateBlog(CreatePostVM vm)
        {
            if (ModelState.IsValid)
            {
                BlogPostRepository repo = new BlogPostRepository();
                repo.WriteBlogPost(vm.NewBlog);

                BlogPostOperations ops = new BlogPostOperations();
                vm.NewBlog.Tags = ops.FormatBlogTagsToList(vm.TagString);

                repo.WriteBlogTags(vm.NewBlog.Tags, vm.NewBlog.BlogId);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [Authorize(Roles = "Contributor")]
        public ActionResult DeactivateBlog(int blogId)
        {
            BlogPostRepository repo = new BlogPostRepository();
            repo.UpdateStatusByBlogId(blogId, (int)Status.Inactive);
            return RedirectToAction("Index", "Contributor");
        }

        [Authorize(Roles = "Contributor")]
        public ActionResult ReactivateBlog(int blogId)
        {
            BlogPostRepository repo = new BlogPostRepository();
            repo.UpdateStatusByBlogId(blogId, (int)Status.Active);
            return RedirectToAction("Index", "Contributor");
        }

        [Authorize(Roles = "Contributor")]
        public ActionResult FilterBlogsByStatus(int? page, Status status)
        {
            BlogPostRepository repo = new BlogPostRepository();
            BlogPostOperations ops = new BlogPostOperations();
            ContributorVM vm = new ContributorVM();
            vm.BlogPosts.AddRange(ops.FilterBlogPostsByStatus(repo.GetByUserId(User.Identity.GetUserId()), status));

            var pageNumber = page ?? 1;
            var onePageOfProducts = vm.BlogPosts.ToPagedList(pageNumber, 6);

            ViewBag.Status = status;
            ViewBag.OnePageOfProducts = onePageOfProducts;

            return View();
        }
    }
}