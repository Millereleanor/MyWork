using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieBFCapstone.Data;
using FoodieBFCapstone.Models;

namespace FoodieBFCapstone.BLL
{
    public class BlogPostOperations
    {
        public List<BlogPost> FilterBlogPostsByStatus(List<BlogPost> allPosts, Status status)
        {
            return allPosts.Where(post => post.StatusId == (int)status).ToList();
        }

        public string FormatBlogTagsToString(int blogId)
        {
            BlogPostRepository repo = new BlogPostRepository();
            List<Tag> tags = repo.ReadAllTagsByBlogId(blogId);
            string tagString = String.Join(",", tags.Select(t => t.TagName));
            return tagString;
        }

        //public List<Tag> FormatBlogTagsToList(string tagString)
        //{
        //    List<string> placeHolder = tagString.Split(',').ToList();
        //    List<Tag> tags = new List<Tag>();

        //    foreach (var p in placeHolder)
        //    {
        //        Tag tag = new Tag { TagName = p };
        //        tags.Add(tag);
        //    }
        //    return tags;
        //}
    }
}
