using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FoodieBFCapstone.Data;
using NUnit.Framework;

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
            var assembly = typeof (RepositoryTests).Assembly; //Gets assembly by class name
            var codebase = new Uri(assembly.CodeBase); 
            var path = codebase.LocalPath.Substring(0, codebase.LocalPath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
            return path;
        }

        [TestFixtureSetUp]
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

        [TestFixtureTearDown]
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
            int expected = 12; // Hard coded number of Blogs inserted from Seed script

            Assert.AreEqual(actual, expected);
        }


    }
}
