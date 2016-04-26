using FoodieBFCapstone.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FoodieBFCapstone.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            this.Subcategory = new Subcategory();
        }

        public int BlogId { get; set; }

        public Guid UserId { get; set; }

        public Subcategory Subcategory { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }
        public string MainPictureUrl { get; set; }

        public bool IsFeatured { get; set; }

        public string Title { get; set; }
        public IdentityProfile Author { get; set; }

        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string PostContent { get; set; }

        public string Summary { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        //[DataType(DataType.Date)]
        public DateTime? ApprovedOn { get; set; }

        public List<Tag> Tags { get; set; }

        public string SubcategoryName { get; set; }
    }
}