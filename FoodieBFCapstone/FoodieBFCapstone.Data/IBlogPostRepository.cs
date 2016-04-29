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

        //BlogPost GetById(int id); --- not sure if needed
        List<BlogPost> GetActivePosts();

        List<BlogPost> GetFeatured();

        List<BlogPost> GetByAuthorUserName(string firstName, string lastName);

        List<BlogPost> GetBySubcategory(string subcategoryType);

        List<BlogPost> GetByTag(string tagName);

        void WriteBlogPost(BlogPost model);

        void Update(int id, BlogPost model);

        void Delete(int id);
    }
}