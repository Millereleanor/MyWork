using FoodieBFCapstone.Data;
using FoodieBFCapstone.UI.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodieBFCapstone.Models;

namespace FoodieBFCapstone.UI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(int? page)
        {
            var repo = new BlogPostRepository();
            var vm = new IndexVM();
            //vm.AllPosts = repo.GetActivePosts();
            vm.AllPosts = repo.GetPostsByStatus((int) Status.Active);
            foreach (var post in vm.AllPosts)
            {
                post.Author = repo.GetAuthorUserNameByBlogId(post.BlogId);
            }
            //vm.FeaturedPosts = repo.GetFeatured();
            vm.FeaturedPosts = repo.GetPostsByStatus((int)Status.Featured);
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

        //public ActionResult Static()
        //{
        //    return View();
        //}

        public ActionResult Details(int blogId)
        {
            
            var repo = new BlogPostRepository();
            var post = repo.GetById(blogId);
            post.Tags = repo.GetBlogPostTags(blogId);
            post.Author = repo.GetAuthorUserNameByBlogId(blogId);
            ViewBag.searchTag = "searchTag";
            ViewBag.searchAuthor = "searchAuthor";
            ViewBag.Author = post.Author.FirstName + " " + post.Author.LastName;
            return View(post);
        }

        //public ActionResult StaticDropDown()
        //{
        //    var repo = new BlogPostRepository();
            
        //    AdminVM pageList = new AdminVM();
        //    List<AdminStaticPage> stuff = repo.GetAdminStaticPages();
        //    pageList.ListStaticPage = stuff;
        //    return View(pageList);
        //}

        public PartialViewResult StaticPageDropDown()
        {
            var repo = new BlogPostRepository();

            AdminVM pageList = new AdminVM();
            List<AdminStaticPage> stuff = repo.GetAdminStaticPages();
            pageList.ListStaticPage = stuff;
            return PartialView(pageList);
        }
        
        public ActionResult Static(int id)
        {
           BlogPostRepository post = new BlogPostRepository();
            var staticPost = post.GetAdminStaticPageById(id);
            
            return View(staticPost);
        }
        
    }
}