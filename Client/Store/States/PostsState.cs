using System.Collections.Generic;
using Fluxor;
using blazor_blog.Shared;

namespace blazor_blog.Client.Store.States
{
    public record PostsState: LoadableState
    {
        public List<Post> Posts { get; init; }
    }

    public class PostsFeatureState : Feature<PostsState>
    {
        public override string GetName()
        {
            return nameof(PostsState);
        }

        protected override PostsState GetInitialState()
        {
            return new PostsState
            {
                IsLoading = false,
                HasError = false,
                ErrorMessage = "",
                Posts = new List<Post>()
            };
        }
    }
}