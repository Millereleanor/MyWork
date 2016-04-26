using FoodieBFCapstone.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FoodieBFCapstone.UI.Models
{
    public class CreatePostVM
    {
        public List<SelectListItem> Subcats { get; set; }
        public BlogPost NewBlog { get; set; }

        public CreatePostVM(List<Subcategory> subcategories)
        {
            Subcats = new List<SelectListItem>();
            foreach (var sub in subcategories)
            {
                var LI = new SelectListItem
                {
                    Text = sub.SubcategoryName,
                    Value = sub.SubcategoryId.ToString()
                };
                Subcats.Add(LI);
            }
        }
    }
}