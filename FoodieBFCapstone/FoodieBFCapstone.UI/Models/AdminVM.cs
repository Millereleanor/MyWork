using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodieBFCapstone.Data;
using FoodieBFCapstone.Models;

namespace FoodieBFCapstone.UI.Models
{
    public class AdminVM
    {
        public List<BlogPost> Blog { get; set; }
        public BlogPost BlogPost { get; set; }
        public List<SelectListItem> BlogStatus { get; set; }
        public AdminStaticPage StaticPage { get; set; }


        public AdminVM()
        {
            BlogStatus = new List<SelectListItem>();
            BlogStatus.Add(new SelectListItem() { Text = "Pending", Value = "1" });
            BlogStatus.Add(new SelectListItem() { Text = "Active", Value = "2" });
            BlogStatus.Add(new SelectListItem() { Text = "Inactive", Value = "3" });
            BlogStatus.Add(new SelectListItem() { Text = "Denied", Value = "4" });
            BlogStatus.Add(new SelectListItem() { Text = "Featured", Value = "5" });
        }


    }
}