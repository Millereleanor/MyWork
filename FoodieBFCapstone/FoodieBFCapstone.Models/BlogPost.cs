using FoodieBFCapstone.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
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

            BlogStatus = new List<SelectListItem>();
            BlogStatus.Add(new SelectListItem() { Text = "Pending", Value = "1" });
            BlogStatus.Add(new SelectListItem() { Text = "Active", Value = "2" });
            BlogStatus.Add(new SelectListItem() { Text = "Inactive", Value = "3" });
            BlogStatus.Add(new SelectListItem() { Text = "Denied", Value = "4" });
            BlogStatus.Add(new SelectListItem() { Text = "Featured", Value = "5" });
        }

        public int BlogId { get; set; }

        public Guid UserId { get; set; }

        public Subcategory Subcategory { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        [Required(ErrorMessage = "Please enter a URL for the main picture")]
        [MaxLength(125)]
        public string MainPictureUrl { get; set; }

        public bool IsFeatured { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a title")]
        [MaxLength(100)]
        public string Title { get; set; }

        public IdentityProfile Author { get; set; }

        [Required(ErrorMessage = "Please enter some content")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "Please enter a summary")]
        [MaxLength(255)]
        public string Summary { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        //[DataType(DataType.Date)]
        public DateTime? ApprovedOn { get; set; }

        public List<Tag> Tags { get; set; }

        public string SubcategoryName { get; set; }

        public List<SelectListItem> BlogStatus { get; set; }
    }
}