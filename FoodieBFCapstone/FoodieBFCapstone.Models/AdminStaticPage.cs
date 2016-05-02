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
        [Required]
        public int AdminPageId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string MiniTitle { get; set; }

        [Required]
        
        public string AdminPageContent { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
