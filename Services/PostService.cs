using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Data;
using TweetBook.Models;

namespace TweetBook.Services
{
    public class PostService : IPostService
    { 
        private readonly DataContext _dataContext;
          
        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<List<PostModel>> GetPostsAsync()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<PostModel> GetPostByIdAsync(Guid postId)
        {
            return await _dataContext.Posts.SingleOrDefaultAsync(x => x.PostId == postId);
        }


        public async Task<bool> UpdatePostAsync(PostModel postForUpdate)
        {    
            if(await GetPostByIdAsync(postForUpdate.PostId) !=null)
            {
                _dataContext.Posts.Update(postForUpdate);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
            

           
           
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);
            if (post != null)
            {
                _dataContext.Posts.Remove(post);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
      
        }

        public async Task<PostModel> CreatePostAsync(string postName, string postBody)
        {
            var newPost = new PostModel { PostId = Guid.NewGuid(), PostBody = postBody, PostName = postName };
            await _dataContext.Posts.AddAsync(newPost);
            await _dataContext.SaveChangesAsync();
            return newPost;
        }
    }
}
