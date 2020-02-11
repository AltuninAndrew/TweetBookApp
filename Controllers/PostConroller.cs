using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Contracts;
using TweetBook.Services;

namespace TweetBook.Controllers
{
    public class PostConroller: Controller
    {
        private readonly IPostService _postService;

        public PostConroller(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetPostsAsync());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid postId)
        {
            var post = await _postService.GetPostByIdAsync(postId);

            if (post != null)
            {
                return Ok(post);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] PatternPostRequest post)
        {
            var newPost =  await _postService.CreatePostAsync(post.PostName, post.PostBody);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

            var endPointUri = $"{baseUrl}/{ApiRoutes.Posts.Create}/{newPost.PostId.ToString()}";

            return Created(endPointUri, newPost);
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid postId, [FromBody]PatternPostRequest postForUpdate)
        {
            var post = new Models.PostModel
            {
                PostId = postId,
                PostBody = postForUpdate.PostBody,
                PostName = postForUpdate.PostName
            };

            var isUpdate = await _postService.UpdatePostAsync(post);

            if(isUpdate)
            {
                return Ok(post);
            } 
            else
            {
                return NotFound();
            }

        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid postId)
        {
            if(await _postService.DeletePostAsync(postId))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
