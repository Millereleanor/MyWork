using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using FoodieBFCapstone.BLL;
using FoodieBFCapstone.Data;
using FoodieBFCapstone.Models;
using FoodieBFCapstone.UI.Models;

namespace FoodieBFCapstone.UI.Controllers
{
    public class ContributorPostsController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody]BlogPost model)
        {
            if (ModelState.IsValid)
            {
                var repo = new BlogPostRepository();
                BlogPostOperations ops = new BlogPostOperations();
                //model.Tags = ops.FormatBlogTagsToList(model.TagString);

                model.BlogId = repo.WriteBlogPost(model);
                repo.WriteBlogTags(model.Tags, model.BlogId);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Errors");
            }
        }
    }
}
