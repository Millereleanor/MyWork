using Dapper;
using FoodieBFCapstone.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieBFCapstone.Data
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private List<BlogPost> Posts = new List<BlogPost>();

        private string constr;

        public BlogPostRepository()
        {
            constr = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        }

        public List<BlogPost> GetAll()
        {
            using (var _cn = new SqlConnection(constr))
            {
                Posts = _cn.Query<BlogPost>("SELECT * FROM BlogPosts").ToList();
                return Posts;
            }
        }

        public List<BlogPost> GetPostByStatus(int Id)
        {
            using (var _cn = new SqlConnection(constr))
            {
                Posts = _cn.Query<BlogPost>("Select * From BlogPosts B Where B.StatusId = @StatusId", new {StatusId = Id}).ToList();
                return Posts;
            }
        } 

        public List<BlogPost> GetActivePosts()
        {
            using (var _cn = new SqlConnection(constr))
            {
                Posts = _cn.Query<BlogPost>("SELECT * FROM BlogPosts WHERE BlogPosts.StatusId=2 Order by BlogPosts.ApprovedOn Desc ").ToList();
                return Posts;
            }
        }

        public List<BlogPost> GetFeatured()
        {
            using (var _cn = new SqlConnection(constr))
            {
                Posts = _cn.Query<BlogPost>("SELECT TOP 3 * FROM BlogPosts WHERE BlogPosts.StatusId=5 ORDER BY Rand()").ToList();
                return Posts;
            }
        }

        public BlogPost GetById(int id)
        {
            BlogPost blogPost = new BlogPost();
            using (var _cn = new SqlConnection(constr))
            {
                blogPost = _cn.Query<BlogPost>("SELECT * " +
                                               "FROM BlogPosts " +
                                               "WHERE BlogId = @BlogId", new { BlogId = id }).FirstOrDefault();
            }
            return blogPost;
        }

        public List<BlogPost> GetByUserId(string userId)
        {
            using (var _cn = new SqlConnection(constr))
            {
                Posts = _cn.Query<BlogPost>("SELECT * " +
                                               "FROM BlogPosts " +
                                               "WHERE UserId = @UserId", new { UserId = userId }).ToList();
            }
            return Posts;
        }

        public List<BlogPost> GetByAuthorUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetBySubcategory(string subcategoryType)
        {
            List<BlogPost> subgategoryPosts = new List<BlogPost>();
            using (var _cn = new SqlConnection(constr))
            {
                subgategoryPosts = _cn.Query<BlogPost>("SELECT BlogPosts.BlogId, BlogPosts.UserId, BlogPosts.SubCategoryId, " +
                                                       "BlogPosts.StatusId, BlogPosts.MainPictureUrl, BlogPosts.Title, " +
                                                       "BlogPosts.PostContent AS [Content], BlogPosts.Summary, BlogPosts.CreatedOn, " +
                                                       "BlogPosts.PublishDate, BlogPosts.ExpirationDate, BlogPosts.ApprovedOn " +
                                                       "FROM BlogPosts INNER JOIN SubCategories ON SubCategories.SubCategoryId = BlogPosts.SubCategoryId " +
                                                       "WHERE (SubCategories.SubCategory = @subcategoryType) " +
                                                       "ORDER BY ApprovedOn", new { subcategoryType = subcategoryType }).ToList();
                return subgategoryPosts;
            }
        }

        public List<BlogPost> GetByTag(string tagName)
        {
            throw new NotImplementedException();
        }

        public void Add(BlogPost model)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, BlogPost model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}