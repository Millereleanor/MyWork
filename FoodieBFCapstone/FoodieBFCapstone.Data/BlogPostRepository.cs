using Dapper;
using FoodieBFCapstone.Identity;
using FoodieBFCapstone.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        public List<BlogPost> GetPostsByStatus(int id)
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
            if (blog.ApprovedOn != null)
            {
                blog.ApprovedOn = (DateTime)dr["ApprovedOn"];
            }
            else
            {
                blog.ApprovedOn = null;
            }

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

        //public List<BlogPost> GetActivePosts()
        //{
        //    using (var _cn = new SqlConnection(constr))
        //    {
        //        Posts = _cn.Query<BlogPost>("SELECT * FROM BlogPosts WHERE BlogPosts.StatusId=2 Order by BlogPosts.ApprovedOn Desc ").ToList();
        //        return Posts;
        //    }
        //}

        //public List<BlogPost> GetFeatured()
        //{
        //    using (var _cn = new SqlConnection(constr))
        //    {
        //        Posts = _cn.Query<BlogPost>("SELECT * FROM BlogPosts WHERE BlogPosts.StatusId=5 ORDER BY NewId()").ToList();
        //        return Posts;
        //    }
        //}

        public BlogPost GetById(int id)
        {
            BlogPost blogPost = new BlogPost();
            using (var _cn = new SqlConnection(constr))
            {
                blogPost = _cn.Query<BlogPost>("SELECT BlogPosts.BlogId, BlogPosts.UserId, BlogPosts.SubCategoryId, " +
                                                       "BlogPosts.StatusId, BlogPosts.MainPictureUrl, BlogPosts.Title, " +
                                                       "BlogPosts.PostContent, BlogPosts.Summary, BlogPosts.CreatedOn, " +
                                                       "BlogPosts.PublishDate, BlogPosts.ExpirationDate, BlogPosts.ApprovedOn, SubCategories.SubCategory AS [SubcategoryName]" +
                                               "FROM BlogPosts INNER JOIN SubCategories ON SubCategories.SubCategoryId = BlogPosts.SubCategoryId " +
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
                                               "WHERE UserId = @UserId " +
                                               "ORDER BY CreatedOn DESC", new { UserId = userId }).ToList();
            }
            return Posts;
        }

        public List<BlogPost> GetByAuthorUserName(string firstName, string lastName)
        {
            using (var _cn = new SqlConnection(constr))
            {
                Posts = _cn.Query<BlogPost>("select bp.*, ip.FirstName, ip.LastName from BlogPosts bp " +
                                            "inner join IdentityProfile ip on bp.UserId = ip.UserId " +
                                            "where ip.firstname = @firstName and ip.LastName = @lastName and bp.StatusId in (5, 2) " +
                                            "ORDER BY ApprovedOn DESC; ", new { FirstName = firstName, LastName = lastName }).ToList();
            }
            return Posts;
        }

        //public List<BlogPost> GetBySubcategory(string subcategoryType)
        //{
        //    List<BlogPost> subgategoryPosts = new List<BlogPost>();
        //    using (var _cn = new SqlConnection(constr))
        //    {
        //        subgategoryPosts = _cn.Query<BlogPost>("SELECT BlogPosts.BlogId, BlogPosts.UserId, BlogPosts.SubCategoryId, " +
        //                                               "BlogPosts.StatusId, BlogPosts.MainPictureUrl, BlogPosts.Title, " +
        //                                               "BlogPosts.PostContent AS [Content], BlogPosts.Summary, BlogPosts.CreatedOn, " +
        //                                               "BlogPosts.PublishDate, BlogPosts.ExpirationDate, BlogPosts.ApprovedOn, SubCategories.SubCategory AS [SubcategoryName]" +
        //                                               "FROM BlogPosts INNER JOIN SubCategories ON SubCategories.SubCategoryId = BlogPosts.SubCategoryId " +
        //                                               "WHERE (SubCategories.SubCategory = @subcategoryType) " +
        //                                               "ORDER BY ApprovedOn DESC", new { subcategoryType = subcategoryType }).ToList();
        //        return subgategoryPosts;
        //    }
        //}

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

        public void UpdateStatusByBlogId(int blogId, int statusId)
        {
            using (var _cn = new SqlConnection(constr))
            {
                _cn.Query("UPDATE BlogPosts " +
                          "SET StatusId = @statusId, ApprovedOn = @date " +

                          "WHERE BlogId = @BlogId", new { statusId, BlogId = blogId, date = DateTime.Today });
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

        public int WriteBlogPost(BlogPost blogPost)
        {
            int blogId = 0;
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("UserId", blogPost.UserId);
                parameters.Add("SubCategoryId", blogPost.Subcategory.SubcategoryId);
                parameters.Add("StatusId", (int)Status.Pending);
                parameters.Add("MainPictureUrl", blogPost.MainPictureUrl);
                parameters.Add("Title", blogPost.Title);
                parameters.Add("PostContent", blogPost.PostContent);
                parameters.Add("Summary", blogPost.Summary);

                if ((blogPost.PublishDate == null) || (blogPost.PublishDate.Value.DayOfYear < 1900))
                    parameters.Add("PublishDate");
                else
                    parameters.Add("PublishDate", blogPost.PublishDate);

                if ((blogPost.ExpirationDate == null) || (blogPost.ExpirationDate.Value.DayOfYear < 1900))
                    parameters.Add("ExpirationDate");
                else
                    parameters.Add("ExpirationDate", blogPost.ExpirationDate);

                parameters.Add("ApprovedOn");

                if (blogPost.BlogId == 0)
                {
                    parameters.Add("CreatedOn", DateTime.Today);
                    parameters.Add("BlogId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    _cn.Execute("InsertBlogPost", parameters, commandType: CommandType.StoredProcedure);

                    blogId = parameters.Get<int>("@BlogId");
                }
                else
                {
                    parameters.Add("BlogId", blogPost.BlogId);
                    parameters.Add("CreatedOn", blogPost.CreatedOn);

                    string updateExistingBlogPost = "UPDATE BlogPosts " +
                                                    "SET UserId = @UserId, SubCategoryId = @SubCategoryId, " +
                                                        "StatusId = @StatusId, MainPictureUrl = @MainPictureUrl, " +
                                                        "Title = @Title, PostContent = @PostContent, " +
                                                        "Summary = @Summary, CreatedOn = @CreatedOn, " +
                                                        "PublishDate = @PublishDate, ExpirationDate = @ExpirationDate, " +
                                                        "ApprovedOn = @ApprovedOn " +
                                                    "WHERE BlogId = @BlogId";
                    _cn.Execute(updateExistingBlogPost, parameters);

                    blogId = blogPost.BlogId;
                }
            }

            return blogId;
        }

        private void WriteTags(List<Tag> blogTags)
        {
            using (var _cn = new SqlConnection(constr))
            {
                foreach (var tag in blogTags)
                {
                    _cn.Query("BEGIN " +
                                "IF NOT EXISTS (SELECT * " +
                                                "FROM Tags " +
                                                "WHERE Tag = @TagName) " +
                                    "BEGIN " +
                                        "INSERT INTO Tags (Tag) " +
                                        "VALUES (@TagName) " +
                                    "END " +
                              "END", new { tag.TagName });
                }
            }
        }

        public void WriteBlogTags(List<Tag> tags, int blogId)
        {
            if ((tags != null) && (tags.Any()))
            {
                WriteTags(tags);

                using (var _cn = new SqlConnection(constr))
                {
                    _cn.Query("DELETE FROM BlogPostsTags WHERE BlogId = @BlogId", new { BlogId = blogId });

                    foreach (var tag in tags)
                    {
                        _cn.Query("DECLARE @TagId int = (SELECT TOP 1 TagId FROM Tags WHERE Tag = @TagName) " +
                                  "BEGIN " +
                                  "IF NOT EXISTS (SELECT * " +
                                  "FROM BlogPostsTags " +
                                  "WHERE BlogId = @BlogId AND TagId = @TagId) " +
                                  "BEGIN " +
                                  "INSERT INTO BlogPostsTags (TagId, BlogId) " +
                                  "VALUES (@TagId, @BlogId) " +
                                  "END " +
                                  "END", new { tag.TagName, BlogId = blogId });
                    }
                }
            }
        }

        public List<Tag> ReadAllTags()
        {
            List<Tag> tags = new List<Tag>();
            using (var _cn = new SqlConnection(constr))
            {
                tags = _cn.Query<Tag>("SELECT TagId, Tag AS TagName " +
                          "FROM Tags").ToList();
            }
            return tags;
        }

        public List<Tag> ReadAllTagsByBlogId(int blogId)
        {
            List<Tag> tags = new List<Tag>();
            using (var _cn = new SqlConnection(constr))
            {
                tags = _cn.Query<Tag>("SELECT t.TagId, t.Tag as TagName " +
                    "FROM Tags t " +
                    "INNER JOIN BlogPostsTags b on t.TagId = b.TagId " +
                    "WHERE b.BlogId = @BlogId", new { BlogId = blogId }).ToList();
            }
            return tags;
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
                Tags = _cn.Query<Tag>("select bp.*, t.Tag as [TagName],t.TagId from BlogPosts bp " +
                           "inner join BlogPostsTags bpt on bp.BlogId = bpt.BlogId " +
                           "inner join Tags t on bpt.TagId = t.TagId " +
                           "where bp.BlogId = @blogId  AND  bp.StatusId in (5,2) ORDER BY ApprovedOn DESC; ", new { BlogId = blogId }).ToList();
                return Tags;
            }
        }

        public List<BlogPost> GetBlogByTitle(string title)
        {
            List<BlogPost> Blogs = new List<BlogPost>();
            using (var _cn = new SqlConnection(constr))
            {
                Blogs = _cn.Query<BlogPost>("select * from BlogPosts bp where bp.Title LIKE  ('%' + @title + '%') AND  bp.StatusId in (5,2) ORDER BY ApprovedOn DESC;", new { Title = title }).ToList();
                return Blogs;
            }
        }

        public List<BlogPost> GetBlogThatContains(string contains)
        {
            List<BlogPost> Posts = new List<BlogPost>();
            contains = "%" + contains + "%";
            using (var _cn = new SqlConnection(constr))
            {
                Posts = _cn.Query<BlogPost>("select * from BlogPosts bp " +
                                            "WHERE bp.PostContent Like ('%' + @contains + '%') " +
                                            "ORDER BY ApprovedOn DESC; ", new { Contains = contains }).ToList();
            }
            return Posts;
        }

        public int CreateStaticPage(AdminStaticPage staticPage)
        {
            int pageId = 0;
            using (var _cn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CreateStaticPage";
                cmd.Parameters.AddWithValue("@Title", staticPage.Title);
                cmd.Parameters.AddWithValue("@MiniTitle", staticPage.MiniTitle);
                cmd.Parameters.AddWithValue("@AdminPageContent", staticPage.AdminPageContent);
                cmd.Parameters.AddWithValue("@CreatedOn", DateTime.Today);

                //SqlParameter outputIDparam = new SqlParameter("@AdminPageId", SqlDbType.Int)
                //{
                //    Direction = ParameterDirection.Output
                //};

                //cmd.Parameters.Add(outputIDparam);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = _cn;
                _cn.Open();
                cmd.ExecuteNonQuery();
                _cn.Close();
            }
            return pageId;
        }

        public List<AdminStaticPage> GetAdminStaticPages()
        {
            List<AdminStaticPage> pages = new List<AdminStaticPage>();
            using (var _cn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * From AdminStaticPages";

                cmd.Connection = _cn;
                _cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        pages.Add(PopulatePagesFromDataReader(dr));
                    }
                }
            }
            return pages;
        }

        private AdminStaticPage PopulatePagesFromDataReader(SqlDataReader dr)
        {
            AdminStaticPage page = new AdminStaticPage();
            page.AdminPageId = (int)dr["AdminPageId"];
            page.Title = dr["Title"].ToString();
            page.MiniTitle = dr["MiniTitle"].ToString();
            page.AdminPageContent = dr["AdminPageContent"].ToString();
            page.CreatedOn = (DateTime)dr["CreatedOn"];

            return page;
        }

        public AdminStaticPage GetAdminStaticPageById(int id)
        {
            AdminStaticPage page = new AdminStaticPage();
            using (var _cn = new SqlConnection(constr))
            {
                page = _cn.Query<AdminStaticPage>("SELECT * " +
                                               "FROM AdminStaticPages " +
                                               "WHERE AdminPageId = @PageId", new { PageId = id }).FirstOrDefault();
            }
            return page;
        }
    }
}