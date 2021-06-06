using SEIIApp.Shared;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;





namespace SEIIApp.Client.Services
{
    // der Service Spricht mit dem Controller Im Backend der HTTP Requests entegegenimmt 
    public class PostServiceAccess
    {
        private HttpClient HttpClient { get; set; }

        public PostServiceAccess(HttpClient client)
        {
            this.HttpClient = client;
        }

        private string GetPostsUrl()
        {
            return "api/PostDefinition";
        }

        private string GetPostUrlWithId(int id)
        {
            return $"{GetPostsUrl()}/{id}";
        }

        public async Task<PostDto> GetPostsWithId(int id)
        {
            return await HttpClient.GetFromJsonAsync<PostDto>(GetPostUrlWithId(id));
        }

        public Task<PostDto[]> GetAllPosts() { 
            return HttpClient.GetFromJsonAsync<PostDto[]>(GetPostsUrl());
        }


        private string Pdfs(String inputType)
        {
            return $"api/PostDefinition/post/{inputType}";
        }

        public async void Save(PostDto post)
        {
            await HttpClient.PutAsJsonAsync(Pdfs("add"), post);
        }

        public async void Delete(int postId)
        {
            await HttpClient.PutAsJsonAsync(Pdfs("delete"), postId);
        }

    }
}