using FoodieBFCapstone.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using FoodieBFCapstone.Data;

namespace FoodieBFCapstone.UI.Models
{
    public class CreatePostVM
    {
        public List<SelectListItem> Subcats { get; set; }
        public BlogPost NewBlog { get; set; }

        public CreatePostVM()
        {
            BlogPostRepository repo = new BlogPostRepository();
            List<Subcategory> subcategories = new List<Subcategory>();
            subcategories = repo.GetAllSubcategories();
            Subcats = new List<SelectListItem>();
            NewBlog = new BlogPost();
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