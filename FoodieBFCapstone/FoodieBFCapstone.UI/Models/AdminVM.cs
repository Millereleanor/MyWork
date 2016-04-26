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

        
        public AdminVM()
        {
            BlogStatus =  new List<SelectListItem>();
            BlogStatus.Add(new SelectListItem() {Text = "Pending", Value = "Pending"});
            BlogStatus.Add(new SelectListItem() { Text = "Active", Value = "Active" });
            BlogStatus.Add(new SelectListItem() { Text = "Inactive", Value = "Inactive" });
            BlogStatus.Add(new SelectListItem() { Text = "Denied", Value = "Inactive" });
            BlogStatus.Add(new SelectListItem() { Text = "Featured", Value = "Inactive" });
        }


    }
}