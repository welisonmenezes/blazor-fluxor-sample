using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using blazor_blog.Shared;
using Microsoft.Extensions.Configuration;

namespace blazor_blog.Client.Services
{
    public class PostService
    {
        private HttpClient http { get; set; }
        private IConfiguration configuration { get; set; }
        private string ApiUrl { get; set; }

        public PostService(HttpClient http, IConfiguration configuration)
        {
            this.http = http;
            this.configuration = configuration;
            this.ApiUrl = this.configuration["ApiUrl"];
        }

        public async Task<List<Post>> GetPosts(int limit = 10)
        {
            List<Post> items;
            items = await this.http.GetFromJsonAsync<List<Post>>($"{this.ApiUrl}posts?_limit={limit}");
            return items;
        }

        public async Task<Post> GetPost(int postId)
        {
            Post post = await this.http.GetFromJsonAsync<Post>($"{this.ApiUrl}posts/{postId}");
            return post;
        }

        public async Task<Post> AddPost(Post post)
        {
            HttpResponseMessage response = await this.http.PostAsJsonAsync($"{this.ApiUrl}posts", post);
            Post savedPost = await response.Content.ReadFromJsonAsync<Post>();
            return savedPost;
        }

        public async Task<Post> UpdatePost(Post post) 
        {
            HttpResponseMessage response = await this.http.PutAsJsonAsync($"{this.ApiUrl}posts/{post.Id}", post);
            Post savedPost = await response.Content.ReadFromJsonAsync<Post>();
            return savedPost;
        }

        public async Task<bool> DeletePost(Post post)
        {
            await this.http.DeleteAsync($"{this.ApiUrl}posts/{post.Id}");
            return true;
        }
    }
}
