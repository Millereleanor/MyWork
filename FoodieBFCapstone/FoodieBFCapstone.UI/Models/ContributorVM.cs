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

            BlogPosts = new List<BlogPost> {NewPost};

            BlogStatus = new List<SelectListItem>
            {
                new SelectListItem() {Text = "All", Value = "0"},
                new SelectListItem() {Text = "Pending", Value = "1"},
                new SelectListItem() {Text = "Active", Value = "2"},
                new SelectListItem() {Text = "Inactive", Value = "3"},
                new SelectListItem() {Text = "Denied", Value = "4"},
                new SelectListItem() {Text = "Featured", Value = "5"}
            };
        }
    }
}