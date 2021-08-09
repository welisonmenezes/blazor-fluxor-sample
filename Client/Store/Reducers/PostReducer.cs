using Fluxor;
using blazor_blog.Client.Store.Actions;
using blazor_blog.Client.Store.States;
using blazor_blog.Shared;

namespace blazor_blog.Client.Store.Reducers
{
    public static class PostReducer
    {
        [ReducerMethod]
        public static PostState OnSetPost(PostState state, SetPostAction action)
        {
            return state with 
            {
                HasError = false,
                ErrorMessage = "",
                IsLoading = false,
                Post = action.Post
            };
        }

        [ReducerMethod]
        public static PostState OnUpdatePost(PostState state, UpdatePostAction action)
        {
            return state with 
            {
                HasError = false,
                ErrorMessage = "",
                IsLoading = false,
                Post = action.Post
            };
        }

        [ReducerMethod]
        public static PostState OnSetErrorPost(PostState state, SetErrorPostAction action)
        {
            return state with 
            {
                HasError = true,
                IsLoading = false,
                ErrorMessage = action.ErrorMessage
            };
        }

        [ReducerMethod]
        public static PostState OnResetPost(PostState state, ResetPostAction action)
        {
            return state with 
            {
                IsLoading = false,
                Post = new Post()
            };
        }

        [ReducerMethod]
        public static PostState OnAsyncLoadPost(PostState state, AsyncLoadPostAction action)
        {
            return state with 
            {
                IsLoading = true
            };
        }

        [ReducerMethod]
        public static PostState OnAsyncUpdatePost(PostState state, AsyncUpdatePostAction action)
        {
            return state with 
            {
                IsLoading = true
            };
        }

        [ReducerMethod]
        public static PostState OnAsyncAddPost(PostState state, AsyncAddPostAction action)
        {
            return state with 
            {
                IsLoading = true
            };
        }

        [ReducerMethod]
        public static PostState OnAsyncDeletePost(PostState state, AsyncDeletePostAction action)
        {
            return state with 
            {
                IsLoading = true
            };
        }

    }
}