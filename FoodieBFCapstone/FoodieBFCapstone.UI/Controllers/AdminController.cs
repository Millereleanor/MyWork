
﻿using System;
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
            List<BlogPost> stuff = repo.GetPostByStatus2(1);
            posts.Blog = stuff; //passing in status enum/db id 
            
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
            List<BlogPost> stuff = repo.GetPostByStatus2(id);
            posts.Blog = stuff;
            BlogPost blog  = new BlogPost();
            
                

            return View(posts);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreatePost(AdminStaticPage page)
        {
            BlogPostRepository repo = new BlogPostRepository();
            repo.CreateStaticPage(page);
            return View();
        }
    }
}

