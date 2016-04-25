using FoodieBFCapstone.Data;
using FoodieBFCapstone.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodieBFCapstone.UI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var repo = new BlogPostRepository();
            var vm = new IndexVM();
            vm.AllPosts = repo.GetActivePosts();
            vm.FeaturedPosts = repo.GetFeatured();

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
    }
}