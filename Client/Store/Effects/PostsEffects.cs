using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fluxor;
using blazor_blog.Shared;
using blazor_blog.Client.Store.Actions;
using blazor_blog.Client.Store.States;
using blazor_blog.Client.Services;

namespace blazor_blog.Client.Store.Effects
{
    public class PostsEffects
    {
        private readonly IState<PostsState> State;
        private readonly PostService PostService;

        public PostsEffects(IState<PostsState> state, PostService postService)
        {
            State = state;
            PostService = postService;
        }

        [EffectMethod]
        public async Task AsyncLoadPostsEffect(AsyncLoadPostsAction action, IDispatcher dispatcher) 
        {
            // SIMULATE LONG ASYNC CALL
            await Task.Delay(1000);
            
            List<Post> posts = await this.PostService.GetPosts();
            dispatcher.Dispatch(new SetPostsAction { Posts = posts });
        }
    }
}