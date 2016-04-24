using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodieBFCapstone.Models;

namespace FoodieBFCapstone.UI.Models
{
    public class ContributorVM
    {
        public List<BlogPost> BlogPosts { get; set; }

        public ContributorVM()
        {
            BlogPosts = new List<BlogPost>();
        }
    }
}