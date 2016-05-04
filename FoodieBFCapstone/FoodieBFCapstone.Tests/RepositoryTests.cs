using FoodieBFCapstone.Data;
using FoodieBFCapstone.Identity;
using FoodieBFCapstone.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodieBFCapstone.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private readonly string _conStr = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        private string _script;
        private BlogPostRepository _repo = new BlogPostRepository();

        private string AssemblyLocation()
        {
            //var assembly = Assembly.GetExecutingAssembly();
            var assembly = typeof(RepositoryTests).Assembly; //Gets assembly by class name
            var codebase = new Uri(assembly.CodeBase);
            var path = codebase.LocalPath.Substring(0,
                codebase.LocalPath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
            return path;
        }

        //[TestFixtureSetUp] // Runs once before set of tests
        [SetUp] // Runs before each test
        public void Init()
        {
            using (SqlConnection cn = new SqlConnection(_conStr))
            {
                _script = File.ReadAllText(AssemblyLocation() + "\\sqlscripts\\Seed.sql");
                SqlCommand cmd = new SqlCommand(_script, cn);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //[TestFixtureTearDown] // Runs once after set of tests
        [TearDown] // Runs after each test
        public void Dispose()
        {
            using (SqlConnection cn = new SqlConnection(_conStr))
            {
                _script = File.ReadAllText(AssemblyLocation() + "\\sqlscripts\\DropData.sql");
                SqlCommand cmd = new SqlCommand(_script, cn);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void ReadAllBlogs()
        {
            int actual = _repo.GetAll().Count;

            // Hard coded number of Blogs inserted from Seed script
            int expected = 12;

            Assert.AreEqual(actual, expected);
        }

        [TestCase(Status.Pending)]
        [TestCase(Status.Active)]
        [TestCase(Status.Featured)]
        public void ReadBlogsByStatus(Status status)
        {
            List<BlogPost> blogs = _repo.GetPostsByStatus((int)status);
            int actual = 0;
            int expected = blogs.Count();

            if (blogs.Any())
            {
                // Increment actual for each blog that matches the status
                actual += blogs.Count(blog => blog.Status == status);
            }

            // Actual should equal blogs.count()
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void ReadAllSubcategories()
        {
            List<Subcategory> actual = _repo.GetAllSubcategories();

            // Hard coded number of Subcategories inserted from Seed script
            int totalSubcategories = 12;

            Assert.AreEqual(actual.Count(), totalSubcategories);

            // Spot checking values
            Assert.AreEqual(actual[0].SubcategoryName, "Breakfast");
            Assert.AreEqual(actual[5].SubcategoryName, "NorthAmerica");
            Assert.AreEqual(actual[11].SubcategoryName, "Antarctica");
        }

        [TestCase(1)]
        public void ReadBlogById(int id)
        {
            BlogPost actual = _repo.GetById(id);

            // Spot checking against hard coded blog info inserted from Seed script
            Assert.AreEqual(actual.BlogId, 1);
            Assert.AreEqual(actual.UserId, new Guid("87e8fca7-c2fa-40d6-b9de-b226056455ac"));
            Assert.AreEqual(actual.StatusId, (int)Status.Pending);
            Assert.AreEqual(actual.MainPictureUrl,
                "https://grubamericana.files.wordpress.com/2012/08/hamburger_love-normal.jpg");
            Assert.AreEqual(actual.Title, "Best Burger Ever!");
            Assert.AreEqual(actual.Summary, "Best Hamburger in the world!");
            Assert.AreEqual(actual.CreatedOn, DateTime.Parse("2016-04-23"));
        }

        [TestCase("87e8fca7-c2fa-40d6-b9de-b226056455ac")] // Jeane Hong
        [TestCase("d4cdc38c-5e60-4238-9c36-bbe39ec4e018")] // Chuck Norris
        public void ReadBlogsByUserId(string userId)
        {
            List<BlogPost> blogs = _repo.GetByUserId(userId);
            int actual = 0;
            int expected = blogs.Count();

            if (blogs.Any())
            {
                // Increment actual for each blog that matches the userId
                actual += blogs.Count(blog => blog.UserId == new Guid(userId));
            }

            // Actual should equal blogs.count()
            Assert.AreEqual(actual, expected);
        }

        [TestCase("Jeane", "Hong", "87e8fca7-c2fa-40d6-b9de-b226056455ac")]
        [TestCase("Chuck", "Norris", "d4cdc38c-5e60-4238-9c36-bbe39ec4e018")]
        public void ReadBlogsByAuthorUserName(string firstName, string lastName, string userId)
        {
            List<BlogPost> blogs = _repo.GetByAuthorUserName(firstName, lastName);
            int actual = 0;
            int expected = blogs.Count();

            if (blogs.Any())
            {
                // Increment actual for each blog that matches the userId
                actual += blogs.Count(blog => blog.UserId == new Guid(userId));
            }

            // Actual should equal blogs.count()
            Assert.AreEqual(actual, expected);
        }

        // Hard coded authors of blog 1 and 2 inserted by Seed script
        [TestCase(1, "Jeane", "Hong")]
        [TestCase(2, "Chuck", "Norris")]
        public void ReadAuthorUserNameByBlogId(int blogId, string firstName, string lastName)
        {
            IdentityProfile actual = _repo.GetAuthorUserNameByBlogId(blogId);

            IdentityProfile expected = new IdentityProfile();
            expected.FirstName = firstName;
            expected.LastName = lastName;

            Assert.AreEqual(actual.FirstName, expected.FirstName);
            Assert.AreEqual(actual.LastName, expected.LastName);
        }

        // Hard coded authors with userId inserted by Seed script
        [TestCase("87e8fca7-c2fa-40d6-b9de-b226056455ac", "Jeane", "Hong")]
        [TestCase("d4cdc38c-5e60-4238-9c36-bbe39ec4e018", "Chuck", "Norris")]
        public void ReadAuthorUserNameByGuid(string id, string firstName, string lastName)
        {
            IdentityProfile actual = _repo.GetAuthorUserGuId(new Guid(id));

            IdentityProfile expected = new IdentityProfile();
            expected.FirstName = firstName;
            expected.LastName = lastName;

            Assert.AreEqual(actual.FirstName, expected.FirstName);
            Assert.AreEqual(actual.LastName, expected.LastName);
        }

        [TestCase(1, (int)Status.Denied, (int)Status.Pending)]
        [TestCase(4, (int)Status.Pending, (int)Status.Featured)]
        public void UpdateStatusByBlogId(int blogId, int newStatus, int originalStatus)
        {
            // Load blog and check initial status
            BlogPost actual = _repo.GetById(blogId);
            Assert.AreEqual(actual.StatusId, originalStatus);

            // Update blog status
            _repo.UpdateStatusByBlogId(blogId, newStatus);

            // Reload blog and check new status
            actual = _repo.GetById(blogId);
            Assert.AreEqual(actual.StatusId, newStatus);
        }

        [TestCase("Noodles", new[] { 6, 8 })]
        [TestCase("Korean food", new[] { 2, 6 })]
        public void ReadBlogsByTag(string tagName, int[] blogsWithTags)
        {
            List<BlogPost> blogs = _repo.GetByTag(tagName);
            int actual = 0;
            int expected = blogs.Count();

            if (blogs.Any())
            {
                // Increment actual for each blog that matches the hard coded blogsWithTags
                actual += blogs.Count(blog => blogsWithTags.Contains(blog.BlogId));
            }

            // Actual should equal blogs.count()
            Assert.AreEqual(actual, expected);
        }

        [TestCase(
            "87e8fca7-c2fa-40d6-b9de-b226056455ac",
            1,
            "http://milkandcuddles.com/wp-content/uploads/2013/06/Cinnamonroll.ashx_.jpg",
            "CinnaMAN Rolls!",
            "<p style=\"text - align: center;\"><img src=\"http://milkandcuddles.com/wp-content/uploads/2013/06/Cinnamonroll.ashx_.jpg\" alt=\"\" width=\"640\" height=\"360\" /></p>",
            "Sticky cinnamon goodness"
            )]
        public void WriteBlogPost(string userId, int subCategory, string picUrl, string title, string postContent,
            string summary)
        {
            BlogPost newBlog = new BlogPost
            {
                UserId = new Guid(userId),
                Subcategory = { SubcategoryId = subCategory },
                MainPictureUrl = picUrl,
                Title = title,
                PostContent = postContent,
                Summary = summary
            };

            newBlog.BlogId = _repo.WriteBlogPost(newBlog);

            BlogPost actual = _repo.GetById(newBlog.BlogId);

            Assert.AreEqual(actual.UserId, new Guid(userId));
            Assert.AreEqual(actual.StatusId, (int)Status.Pending);
            Assert.AreEqual(actual.MainPictureUrl, picUrl);
            Assert.AreEqual(actual.Title, title);
            Assert.AreEqual(actual.PostContent, postContent);
            Assert.AreEqual(actual.Summary, summary);
            Assert.AreEqual(actual.CreatedOn, DateTime.Today);
        }

        private static readonly object[] TagList = {
            new object[] {
                new List<Tag>{
                    new Tag {TagName = "Meatzilla"},
                    new Tag {TagName = "Bomb Ass Ribz"},
                    new Tag {TagName = "1 Doesnt Exist"},
                    new Tag {TagName = "2 Doesnt Exist"}
                }
            }
        };

        [Test, TestCaseSource("TagList")]
        public void WriteTagsIgnoringDuplicates(List<Tag> listOfTags)
        {
            // Gets initial count of tags
            int expected = _repo.ReadAllTags().Count;

            // Writes tags
            int blogId = 1;
            _repo.WriteBlogTags(listOfTags, blogId);

            // Gets new count of tags
            int actualCount = _repo.ReadAllTags().Count;

            Assert.AreEqual(actualCount, expected + 2); // Plus two instead of 4 to show duplicates being excluded
        }

        [Test, TestCaseSource("TagList")]
        public void WriteBlogTags(List<Tag> expectedTags)
        {
            int blogId = 2;
            _repo.WriteBlogTags(expectedTags, blogId);

            List<Tag> blogTags = _repo.ReadAllTagsByBlogId(blogId);

            Assert.AreEqual(blogTags.Count, 4);

            foreach (var tag in blogTags)
            {
                Assert.AreEqual(expectedTags.Any(m => m.TagName == tag.TagName), true);
            }
        }

        [Test]
        public void ReadAllTags()
        {
            int actual = _repo.ReadAllTags().Count;
            int expected = 24;

            Assert.AreEqual(actual, expected);
        }

        [TestCase(1, 1)]
        [TestCase(2, 3)]
        [TestCase(6, 2)]
        public void ReadTagsByBlogId(int blogId, int expected)
        {
            int actual = _repo.ReadAllTagsByBlogId(blogId).Count;

            Assert.AreEqual(actual, expected);
        }

        [TestCase("NorthAmerica", 1)]
        [TestCase("Dinner", 1)]
        [TestCase("Asia", 0)]
        public void GetActivePostsinSubCategory(string subcategoryType, int expected)
        {
            int actual = _repo.GetActivePostsinSubCategory(subcategoryType).Count;
            Assert.AreEqual(actual, expected);
        }

        [TestCase(1, 1)]
        [TestCase(2, 3)]
        public void GetBlogPostTags(int blogId, int expected)
        {
            int actual = _repo.GetBlogPostTags(blogId).Count;
            Assert.AreEqual(actual, expected);
        }

        [TestCase("Korea", 1)]
        public void GetBlogByTitle(string title, int expected)
        {
            int actual = _repo.GetBlogByTitle(title).Count;
            Assert.AreEqual(actual, expected);
        }

        [TestCase("Strawberry", 1)]
        public void GetBlogThatContains(string contains, int expected)
        {
            int actual = _repo.GetBlogThatContains(contains).Count;
            Assert.AreEqual(actual, expected);
        }
    }
}