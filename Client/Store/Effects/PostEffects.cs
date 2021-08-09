using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fluxor;
using blazor_blog.Shared;
using blazor_blog.Client.Store.Actions;
using blazor_blog.Client.Store.States;
using blazor_blog.Client.Services;

namespace blazor_blog.Client.Store.Effects
{
    public class PostEffects
    {
        private readonly IState<PostState> State;
        private readonly IState<PostsState> PostsState;
        private readonly PostService PostService;

        public PostEffects(IState<PostState> state, PostService postService, IState<PostsState> postsState)
        {
            State = state;
            PostService = postService;
            PostsState = postsState;
        }

 
        [EffectMethod]
        public async Task LoadPostEffect(AsyncLoadPostAction action, IDispatcher dispatcher) 
        {
            if (action.Id != 0)
            {
                // SIMULATE LONG ASYNC CALL
                await Task.Delay(1000);

                Post post = await this.PostService.GetPost(action.Id);
                dispatcher.Dispatch(new SetPostAction { Post = post });
            }
            else 
            {
                dispatcher.Dispatch(new ResetPostAction());
            }
        }


        [EffectMethod]
        public async Task AsyncUpdatePostEffect(AsyncUpdatePostAction action, IDispatcher dispatcher) 
        {
            // SIMULATE LONG ASYNC CALL
            await Task.Delay(1000);

            // consulta o serviço
            Post post = await this.PostService.UpdatePost(action.Post);

            // Atualiza o post
            dispatcher.Dispatch(new UpdatePostAction { Post = post });

            // Atualiza a lista de posts
            await Task.Delay(1);
            dispatcher.Dispatch(new UpdateSinglePostPostsAction{ Post = post });
        }


        [EffectMethod]
        public async Task AsyncAddPostEffect(AsyncAddPostAction action, IDispatcher dispatcher) 
        {
            // SIMULATE LONG ASYNC CALL
            await Task.Delay(1000);

            // consulta o serviço
            Post post = await this.PostService.AddPost(action.Post);

            // set a fake id
            post.Id = PostsState.Value.Posts.Max(p => p.Id) + 1;
            
            // Atualiza o post
            dispatcher.Dispatch(new UpdatePostAction { Post = post });

            // Atualiza a lista de posts
            await Task.Delay(1);
            dispatcher.Dispatch(new UpdateSinglePostPostsAction{ Post = post });
        }

        [EffectMethod]
        public async Task AsyncDeletePostEffect(AsyncDeletePostAction action, IDispatcher dispatcher) 
        {
            // SIMULATE LONG ASYNC CALL
            await Task.Delay(1000);

            // consulta o serviço
            bool isDeleted = await this.PostService.DeletePost(action.Post);

            if (isDeleted)
            {
                // reseta state atual
                dispatcher.Dispatch(new ResetPostAction());

                // Atualiza a lista de posts
                await Task.Delay(1);
                dispatcher.Dispatch(new DeleteSinglePostPostsAction{ Post = action.Post });
            }
        }
    }
}