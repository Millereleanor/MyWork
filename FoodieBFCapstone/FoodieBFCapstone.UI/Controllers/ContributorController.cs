using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using FoodieBFCapstone.Data;
using FoodieBFCapstone.Models;

namespace FoodieBFCapstone.UI.Controllers
{
    public class ContributorController : Controller
    {
        [Authorize(Roles = "Contributor")]
        public ActionResult Index()
        {
            BlogPostRepository repo = new BlogPostRepository();
            List<BlogPost> blogs = repo.GetByUserId(User.Identity.GetUserId());
            return View(blogs);
        }
    }
}