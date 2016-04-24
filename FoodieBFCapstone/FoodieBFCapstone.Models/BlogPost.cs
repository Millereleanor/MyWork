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
        public int BlogPostId { get; set; }

        //not sure about this one???
        //public int ContributorId { get; set; }

        public Subcategory Subcategory { get; set; }

        public Status Status { get; set; }
        public bool IsFeatured { get; set; }

        public string Title { get; set; }

        public string MainPictureUrl { get; set; }
        public string Summary { get; set; }

        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public DateTime? ApprovedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<Tag> Tags { get; set; }
    }
}