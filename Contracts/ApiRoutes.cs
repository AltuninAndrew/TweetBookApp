using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBook.Contracts
{
    public static class ApiRoutes
    {
        public static class Posts
        {
            public const string GetAll = "api/posts";
            public const string Get = "api/posts/{postId}";
            public const string Delete = "api/posts/{postId}";
            public const string Create = "api/posts";
            public const string Update = "api/posts/{postId}";
        }
    
    }
}
