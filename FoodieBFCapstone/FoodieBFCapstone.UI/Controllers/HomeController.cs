using FoodieBFCapstone.Data;
using FoodieBFCapstone.UI.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodieBFCapstone.UI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(int? page)
        {
            var repo = new BlogPostRepository();
            var vm = new IndexVM();
            vm.AllPosts = repo.GetActivePosts();
            foreach (var post in vm.AllPosts)
            {
                post.Author = repo.GetAuthorUserNameByBlogId(post.BlogId);
            }
            vm.FeaturedPosts = repo.GetFeatured();
            foreach (var post in vm.FeaturedPosts)
            {
                post.Author = repo.GetAuthorUserNameByBlogId(post.BlogId);
            }
            var pageNumber = page ?? 1;
            var onePageOfProducts = vm.AllPosts.ToPagedList(pageNumber, 5);

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Static()
        {
            return View();
        }

        public ActionResult Details(int blogId)
        {
            var repo = new BlogPostRepository();
            var post = repo.GetById(blogId);
            post.Author = repo.GetAuthorUserNameByBlogId(blogId);
            return View(post);
        }
    }
}