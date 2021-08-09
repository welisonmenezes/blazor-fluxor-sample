using System.Collections.Generic;
using Fluxor;
using blazor_blog.Client.Store.Actions;
using blazor_blog.Client.Store.States;
using blazor_blog.Shared;

namespace blazor_blog.Client.Store.Reducers
{
    public static class PostsReducer
    {
        [ReducerMethod]
        public static PostsState OnSetPosts(PostsState state, SetPostsAction action)
        {
            return state with 
            {
                HasError = false,
                ErrorMessage = "",
                IsLoading = false,
                Posts = action.Posts
            };
        }

        [ReducerMethod]
        public static PostsState OnUpdateSinglePostPosts(PostsState state, UpdateSinglePostPostsAction action)
        {
            List<Post> newPosts = new List<Post>(state.Posts);
            Post post = newPosts.Find(p => p.Id == action.Post.Id);
            
            if (post != null)
            {
                post.Id = action.Post.Id;
                post.Title = action.Post.Title;
                post.Body = action.Post.Body;
                post.UserId = action.Post.UserId;
            }
            else 
            {
                newPosts.Insert(0, action.Post);
            }

            return state with 
            {
                Posts = newPosts
            };
        }

        [ReducerMethod]
        public static PostsState OnSetErrorPosts(PostsState state, SetErrorPostsAction action)
        {
            return state with 
            {
                HasError = true,
                IsLoading = false,
                ErrorMessage = action.ErrorMessage
            };
        }

        [ReducerMethod]
        public static PostsState OnAsyncLoadPosts(PostsState state, AsyncLoadPostsAction action)
        {
            return state with 
            {
                IsLoading = true
            };
        }

        [ReducerMethod]
        public static PostsState OnDeleteSinglePostPosts(PostsState state, DeleteSinglePostPostsAction action)
        {
            List<Post> newPosts = new List<Post>(state.Posts);
            Post post = newPosts.Find(p => p.Id == action.Post.Id);

            if (post != null)
            {
                newPosts.Remove(post);
            }

            return state with
            {
                Posts = newPosts
            };
        }
    }
}