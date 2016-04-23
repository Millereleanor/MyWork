using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieBFCapstone.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }

        //not sure about this one???
        //public int ContributorId { get; set; }

        public Subcategory Subcategory { get; set; }

        public Status Status { get; set; }

        public string Title { get; set; }

        public string MainPictureUrl { get; set; }

        //this is the info is gotten by the tinymce ...
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime ApprovedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        //tags??????????????????????????????????????????????????
    }
}