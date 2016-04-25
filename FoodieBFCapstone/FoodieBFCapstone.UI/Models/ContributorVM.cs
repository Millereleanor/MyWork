using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodieBFCapstone.Models;

namespace FoodieBFCapstone.UI.Models
{
    public class ContributorVM
    {
        public BlogPost NewPost { get; set; }
        public List<BlogPost> BlogPosts { get; set; }

        public ContributorVM()
        {
            NewPost = new BlogPost();
            NewPost.Title = "Create New";
            NewPost.MainPictureUrl = "~/Content/pictures/logo22.png";

            BlogPosts = new List<BlogPost>();
            BlogPosts.Add(NewPost);
        }
    }
}