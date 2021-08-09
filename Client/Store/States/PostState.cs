using Fluxor;
using blazor_blog.Shared;

namespace blazor_blog.Client.Store.States
{
    public record PostState: LoadableState
    {
        public Post Post { get; init; }
    }

    public class PostFeatureState : Feature<PostState>
    {
        public override string GetName()
        {
            return nameof(PostState);
        }

        protected override PostState GetInitialState()
        {
            return new PostState
            {
                IsLoading = false,
                HasError = false,
                ErrorMessage = "",
                Post = new Post()
            };
        }
    }
}