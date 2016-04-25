using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodieBFCapstone.Models;

namespace FoodieBFCapstone.UI.Models
{
    public class ContributorVM
    {
        public BlogPost NewPost { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
        public List<SelectListItem> BlogStatus { get; set; }

        public ContributorVM()
        {
            NewPost = new BlogPost
            {
                Title = "Create New",
                MainPictureUrl = "~/Content/pictures/logo22.png"
            };

            BlogPosts = new List<BlogPost>();
            BlogPosts.Add(NewPost);

            BlogStatus = new List<SelectListItem>();
            BlogStatus.Add(new SelectListItem() { Text = "All", Value = "0"});
            BlogStatus.Add(new SelectListItem() {Text = "Pending", Value = "1" });
            BlogStatus.Add(new SelectListItem() { Text = "Active", Value = "2" });
            BlogStatus.Add(new SelectListItem() { Text = "Inactive", Value = "3" });
            BlogStatus.Add(new SelectListItem() { Text = "Denied", Value = "4" });
            BlogStatus.Add(new SelectListItem() { Text = "Featured", Value = "5" });
        }
    }
}