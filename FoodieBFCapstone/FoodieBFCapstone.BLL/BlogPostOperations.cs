using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieBFCapstone.Models;

namespace FoodieBFCapstone.BLL
{
    public class BlogPostOperations
    {
        public List<BlogPost> FilterBlogPostsByStatus(List<BlogPost> allPosts, Status status)
        {
            return allPosts.Where(post => post.Status == status).ToList();
        }
    }
}
