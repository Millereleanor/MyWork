using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodieBFCapstone.Data;
using FoodieBFCapstone.Models;

namespace FoodieBFCapstone.UI.Controllers
{
    public class AdminController : Controller
    {
        BlogPostRepository repo = new BlogPostRepository();
        // GET: Admin
        public ActionResult Home()
        {
            List<BlogPost> posts = repo.GetPostByStatus(4);
            return View(posts);
        }
    }
}