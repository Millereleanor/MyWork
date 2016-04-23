using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieBFCapstone.Models
{
    public class Subcategory
    {
        public int SubcategoryId { get; set; }

        public string Type { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}