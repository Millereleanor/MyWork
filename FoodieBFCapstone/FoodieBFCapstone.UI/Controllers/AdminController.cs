
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
﻿using System.Web.UI.WebControls;
﻿using FoodieBFCapstone.Data;
using FoodieBFCapstone.Models;
﻿using FoodieBFCapstone.UI.Models;

namespace FoodieBFCapstone.UI.Controllers
{
    public class AdminController : Controller
    {

        
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Home()
        {
            BlogPostRepository repo = new BlogPostRepository();
            AdminVM posts = new AdminVM();
            List<BlogPost> stuff = repo.GetPostsByStatus((int)Status.Pending);
            posts.Blog = stuff; //passing in status enum/db id 
            foreach (var post in posts.Blog)
            {
                post.Author = repo.GetAuthorUserNameByBlogId(post.BlogId);
            }
            return View(posts);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateStatus(int StatusId, int blogId)
        {
            BlogPostRepository repo = new BlogPostRepository();
            repo.UpdateStatusByBlogId(blogId, StatusId);
            return RedirectToAction("Home");
        }


        [Authorize(Roles = "Admin")]
        public ActionResult StatusFilter(int id)
        {
            BlogPostRepository repo = new BlogPostRepository();
            AdminVM posts = new AdminVM();
            List<BlogPost> stuff = repo.GetPostsByStatus(id);
            posts.Blog = stuff;
            ViewBag.status = (Status) id;
            foreach (var post in posts.Blog)
            {
                post.Author = repo.GetAuthorUserNameByBlogId(post.BlogId);
            }
            return View(posts);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreatePost()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(AdminVM model)
        {
            BlogPostRepository repo = new BlogPostRepository();
            repo.CreateStaticPage(model.StaticPage);
            return RedirectToAction("Home");
        }

        //public ActionResult ViewAdminPost()
        //{
            
        //}
    }
}

