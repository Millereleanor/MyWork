using FoodieBFCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieBFCapstone.Data
{
    public interface IBlogPostRepository
    {
        List<BlogPost> GetAll();

        List<BlogPost> GetPostsByStatus(int id);

        List<BlogPost> GetByAuthorUserName(string firstName, string lastName);

        //List<BlogPost> GetBySubcategory(string subcategoryType);

        List<BlogPost> GetByTag(string tagName);

        int WriteBlogPost(BlogPost model);
    }
}