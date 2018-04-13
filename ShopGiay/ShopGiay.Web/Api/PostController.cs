
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;
using TeduShop.Web.Infrastructure.Extensions;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/post")]
    public class PostController : ApiControllerBase
    {
        IPostService _postService;
        public PostController(IErrorService errorService, IPostService postService)
            : base(errorService)
        {
            this._postService = postService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, PostView post)
        {
            return CreateHttpResponse(request, () =>
            {
                var listPost = _postService.GetAll();
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, listPost);
                return reponse;
            });
        }

        public HttpResponseMessage Create(HttpRequestMessage request, PostViewModel postVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Post newPost = new Post();
                    newPost.UpdatePost(postVm);
                    var postcategory = _postService.Add(newPost);
                    _postService.SaveChanges();
                    reponse = request.CreateResponse(HttpStatusCode.Created, postcategory);
                }
                return reponse;
            });
        }

    }
}
