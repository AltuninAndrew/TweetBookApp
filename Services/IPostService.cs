using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Models;

namespace TweetBook.Services
{
    public interface IPostService
    {
        Task<List<PostModel>> GetPostsAsync();

        Task<PostModel> GetPostByIdAsync(Guid postId);

        Task<bool> UpdatePostAsync(PostModel postForUpdate);

        Task<bool> DeletePostAsync(Guid postId);

        Task<PostModel> CreatePostAsync(string postName, string postBody);

    }
}
