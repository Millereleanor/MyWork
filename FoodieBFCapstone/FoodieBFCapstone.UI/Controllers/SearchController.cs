using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodieBFCapstone.Data;
using FoodieBFCapstone.Models;
using PagedList;

namespace FoodieBFCapstone.UI.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Search(string text, string type, int? page)
        {
            var repo = new BlogPostRepository();
            List<BlogPost> posts = new List<BlogPost>();
            switch (type)
            {
                case "searchTag":
                    posts = repo.GetByTag(text);

                    break;

                case "searchBlogTitle":
                    posts = repo.GetBlogByTitle(text);

                    break;

                case "searchAuthor":
                    var searchterms = text.Split(' ');
                    string firstName = searchterms[0];
                    string lastName = searchterms[1];
                    posts = repo.GetByAuthorUserName(firstName, lastName);

                    break;

                case "searchBlogContains":
                    posts = repo.GetBlogThatContains(text);

                    break;

            }
            foreach (var post in posts)
            {
                post.Author = repo.GetAuthorUserNameByBlogId(post.BlogId);
            }
            var pageNumber = page ?? 1;
            var onePageOfProducts = posts.ToPagedList(pageNumber, 5);

            ViewBag.OnePageOfProducts = onePageOfProducts;
            ViewBag.Type = type;
            ViewBag.Text = text;

            return View(posts);
        }

    }

}