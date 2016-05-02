using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodieBFCapstone.Data;
using FoodieBFCapstone.Models;

namespace FoodieBFCapstone.UI.Controllers
{
    public class TagsController : ApiController
    {
        public List<string> Get()
        {
            BlogPostRepository repo = new BlogPostRepository();
            List<Tag> allTags = repo.ReadAllTags();
            List<string> tagNames = allTags.Select(tag => tag.TagName).ToList();
            return tagNames;
        } 
    }
}
