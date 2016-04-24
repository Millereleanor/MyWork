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
        //[Authorize(Roles = "Contributor")]
        //public ActionResult Index()
        //{
        //    BlogPostRepository repo = new BlogPostRepository();
        //    ContributorVM vm = new ContributorVM();
        //    vm.BlogPosts = repo.GetByUserId(User.Identity.GetUserId());
        //    return View(vm);
        //}

        [Authorize(Roles = "Contributor")]
        public ActionResult Index(int? page)
        {
            BlogPostRepository repo = new BlogPostRepository();
            ContributorVM vm = new ContributorVM();
            vm.BlogPosts.AddRange(repo.GetByUserId(User.Identity.GetUserId()));

            var pageNumber = page ?? 1;
            var onePageOfProducts = vm.BlogPosts.ToPagedList(pageNumber, 2);

            var peek = vm.BlogPosts;

            ViewBag.OnePageOfProducts = onePageOfProducts;

            return View();
        }
    }

}
