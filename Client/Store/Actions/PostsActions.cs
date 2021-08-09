using System.Collections.Generic;
using blazor_blog.Shared;

namespace blazor_blog.Client.Store.Actions
{
    public record SetErrorPostsAction
    {
        public string ErrorMessage { get; set; }
    }

    public record SetPostsAction
    {
        public List<Post> Posts { get; set; }
    }

    public record UpdateSinglePostPostsAction
    {
        public Post Post { get; set; }
    }

    public record DeleteSinglePostPostsAction
    {
        public Post Post { get; set; }
    }

    public record AsyncLoadPostsAction 
    { }
}