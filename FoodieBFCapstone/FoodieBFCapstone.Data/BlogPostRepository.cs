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
                var Subcategories = _cn.Query<Subcategory>("SELECT SubCategoryId, CategoryId, SubCategory AS SubCategoryName FROM SubCategories ").ToList();
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

        public IdentityProfile GetAuthorUserGuId(Guid id)
        {
            IdentityProfile Author = new IdentityProfile();
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                Author = _cn.Query<IdentityProfile>("SELECT * FROM IdentityUser " +
                                                    "INNER JOIN IdentityProfile " +
                                                    "ON IdentityUser.UserId = IdentityProfile.UserId " +
                                                    "Where IdentityUser.UserId = @ID", parameters).FirstOrDefault();
                return Author;
            }
        }

        public void UpdateStatusByBlogId(int blogId, int StatusId)
        {
            using (var _cn = new SqlConnection(constr))
            {
                _cn.Query("UPDATE BlogPosts " +
                          "SET StatusId = @statusId " +
                          "WHERE BlogId = @BlogId", new { statusId = StatusId, BlogId = blogId });
            }
        }

        public List<BlogPost> GetByTag(string tagName)
        {
            List<BlogPost> blogPostsWithATag = new List<BlogPost>();
            using (var _cn = new SqlConnection(constr))
            {
                blogPostsWithATag = _cn.Query<BlogPost>("select bp.*, t.Tag as [TagName] from BlogPosts bp " +
                           "inner join BlogPostsTags bpt on bp.BlogId = bpt.BlogId " +
                           "inner join Tags t on bpt.TagId = t.TagId " +
                           "where Tag = @tagName; ", new { TagName = tagName }).ToList();
                return blogPostsWithATag;
            }
        }

        public void Add(BlogPost model)
        {
            Posts = GetAll();
            model.CreatedOn = DateTime.Today;
            model.Status = Status.Pending;
            int statusId = (int)model.Status;

            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                //[BlogId],[UserId],[SubCategoryId],[StatusId],[MainPictureUrl],[Title],[PostContent],[CreatedOn],
                //[PublishDate],[ExpirationDate],[ApprovedOn] FROM[FoodieAndTheBlowFish].[dbo].[BlogPosts]
                parameters.Add("UserId", model.UserId);
                parameters.Add("SubCategoryId", model.Subcategory.SubcategoryId);
                parameters.Add("Summary", model.Summary);
                parameters.Add("StatusId", statusId);
                parameters.Add("MainPictureUrl", model.MainPictureUrl);
                parameters.Add("Title", model.Title);
                parameters.Add("PostContent", model.PostContent);
                parameters.Add("CreatedOn", model.CreatedOn.ToShortDateString());
                if (model.PublishDate != null)
                {
                    parameters.Add("PublishDate", model.PublishDate.Value.ToShortDateString());
                }
                else
                {
                    parameters.Add("PublishDate", null);
                }

                if (model.ExpirationDate != null)
                {
                    parameters.Add("ExpirationDate", model.ExpirationDate.Value.ToShortDateString());
                }
                else
                {
                    parameters.Add("ExpirationDate", null);
                }
                string query = "INSERT INTO BlogPosts (UserId, StatusId, SubCategoryId, Summary, MainPictureUrl, Title, PostContent, CreatedOn, PublishDate, ExpirationDate) " +
                    " VALUES (@UserId, @StatusId, @SubCategoryId, @Summary, @MainPictureUrl, @Title, @PostContent, @CreatedOn, @PublishDate, @ExpirationDate) ";
                _cn.Execute(query, parameters);
            }
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

        public List<Tag> GetBlogPostTags(int blogId)
        {
            List<Tag> Tags = new List<Tag>();
            using (var _cn = new SqlConnection(constr))
            {
                Tags = _cn.Query<Tag>("select bp.BlogId, t.Tag as [TagName],t.TagId from BlogPosts bp " +
                           "inner join BlogPostsTags bpt on bp.BlogId = bpt.BlogId " +
                           "inner join Tags t on bpt.TagId = t.TagId " +
                           "where bp.BlogId = @blogId ; ", new { BlogId = blogId }).ToList();
                return Tags;
            }
        }
    }
}