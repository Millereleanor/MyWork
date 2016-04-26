using Dapper;
using FoodieBFCapstone.Identity;
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


        public List<BlogPost> GetPostByStatus2(int id)
        {
            List<BlogPost> blogs = new List<BlogPost>();
            using (var cn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * From BlogPosts b " +
                                  "Inner Join Statuses s on b.StatusId = s.StatusId " +
                                  "Inner Join SubCategories s2 on b.SubCategoryId = s2.SubCategoryId " +
                                  "Inner Join BlogPostsTags bp on b.BlogId = bp.BlogId " +
                                  "Where b.StatusId = " + id;
               
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        blogs.Add(PopulateFromDataReader(dr));
                    }
                }
            }
            return blogs;
        }

        private BlogPost PopulateFromDataReader(SqlDataReader dr)
        {
            BlogPost blog = new BlogPost();
            blog.Subcategory = new Subcategory();
            blog.Status = (Status)dr["StatusId"];
            blog.Title = dr["Title"].ToString();
            blog.PostContent = dr["PostContent"].ToString();
            blog.Summary = dr["Summary"].ToString();
            
            blog.BlogId = (int)dr["BlogId"];
            blog.MainPictureUrl = dr["MainPictureUrl"].ToString();
            blog.Subcategory.SubcategoryName = dr["SubCategory"].ToString();
            blog.CreatedOn = (DateTime)dr["CreatedOn"];

            return blog;
        }

        public List<Subcategory> GetAllSubcategories()
        {
            using (var _cn = new SqlConnection(constr))
            {
                var Subcategories = _cn.Query<Subcategory>("SELECT * FROM SubCategories ").ToList();
                return Subcategories;
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
                Posts = _cn.Query<BlogPost>("SELECT TOP 3 * FROM BlogPosts WHERE BlogPosts.StatusId=5 ORDER BY NewId()").ToList();
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
                                                       "BlogPosts.PublishDate, BlogPosts.ExpirationDate, BlogPosts.ApprovedOn, SubCategories.SubCategory AS [SubcategoryName]" +
                                                       "FROM BlogPosts INNER JOIN SubCategories ON SubCategories.SubCategoryId = BlogPosts.SubCategoryId " +
                                                       "WHERE (SubCategories.SubCategory = @subcategoryType) " +
                                                       "ORDER BY ApprovedOn DESC", new { subcategoryType = subcategoryType }).ToList();
                return subgategoryPosts;
            }
        }

        public IdentityProfile GetAuthorUserNameByBlogId(int id)
        {
            IdentityProfile Author = new IdentityProfile();
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                Author = _cn.Query<IdentityProfile>("SELECT * FROM BlogPosts " +
                                                    "INNER JOIN IdentityUser " +
                                                    "ON BlogPosts.UserId = IdentityUser.UserId " +
                                                    "INNER JOIN IdentityProfile " +
                                                    "ON IdentityUser.UserId = IdentityProfile.UserId " +
                                                    "Where BlogPosts.BlogId = @ID", parameters).FirstOrDefault();
                return Author;
            }
        }

        public void UpdateStatusByBlogId(int blogId, Status status)
        {
            using (var _cn = new SqlConnection(constr))
            {
                _cn.Query("UPDATE BlogPosts " +
                          "SET StatusId = @StatusId " +
                          "WHERE BlogId = @BlogId", new { StatusId = status, BlogId = blogId });
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

        public List<BlogPost> GetActivePostsinSubCategory(string subcategoryType)
        {
            List<BlogPost> subgategoryPosts = new List<BlogPost>();
            using (var _cn = new SqlConnection(constr))
            {
                subgategoryPosts =
                    _cn.Query<BlogPost>("SELECT BlogPosts.BlogId, BlogPosts.UserId, BlogPosts.SubCategoryId, " +
                                        "BlogPosts.StatusId, BlogPosts.MainPictureUrl, BlogPosts.Title, " +
                                        "BlogPosts.PostContent AS [Content], BlogPosts.Summary, BlogPosts.CreatedOn, " +
                                        "BlogPosts.PublishDate, BlogPosts.ExpirationDate, BlogPosts.ApprovedOn, SubCategories.SubCategory AS [SubcategoryName] " +
                                        "FROM BlogPosts INNER JOIN SubCategories ON SubCategories.SubCategoryId = BlogPosts.SubCategoryId " +
                                        "WHERE (SubCategories.SubCategory = @subcategoryType) AND BlogPosts.StatusId in (5,2) " +
                                        "ORDER BY ApprovedOn Desc", new { subcategoryType = subcategoryType }).ToList();
                return subgategoryPosts;
            }
        }
    }
}