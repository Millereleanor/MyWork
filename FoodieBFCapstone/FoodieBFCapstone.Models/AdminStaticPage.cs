using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FoodieBFCapstone.Models
{
    public class AdminStaticPage
    {
       
        public int AdminPageId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter a Title for your post!")]
        public string Title { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Give your link a title.")]
        public string MiniTitle { get; set; }

        [Required(ErrorMessage = "Don't you want to share your latest adventure? Enter in some content!")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string AdminPageContent { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
