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

        [MaxLength(100, ErrorMessage = "Your title is too long!")]
        [Required(ErrorMessage = "Please enter a Title for your post!")]
        public string Title { get; set; }

        [MaxLength(20, ErrorMessage = "Your Link Name is too long!")]
        [Required(ErrorMessage = "Give your link a title.")]
        public string MiniTitle { get; set; }

        [Required(ErrorMessage = "Don't you want to share your latest adventure? Enter in some content!")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string AdminPageContent { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
