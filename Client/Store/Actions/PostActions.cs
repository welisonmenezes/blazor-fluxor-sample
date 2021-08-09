using System.Collections.Generic;
using blazor_blog.Shared;

namespace blazor_blog.Client.Store.Actions
{
    public record SetErrorPostAction
    {
        public string ErrorMessage { get; set; }
    }

    public record SetPostAction
    {
        public Post Post { get; set; }
    }

    public record UpdatePostAction
    {
        public Post Post { get; set; }
    }

    public record ResetPostAction
    { }

    public record AsyncLoadPostAction 
    { 
        public int Id { get; set; }
    }

    public record AsyncUpdatePostAction
    {
        public Post Post { get; set; }
    }

    public record AsyncAddPostAction
    {
        public Post Post { get; set; }
    }

    public record AsyncDeletePostAction
    {
        public Post Post { get; set; }
    }
}