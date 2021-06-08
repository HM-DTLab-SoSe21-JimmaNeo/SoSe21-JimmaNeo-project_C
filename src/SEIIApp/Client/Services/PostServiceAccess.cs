using SEIIApp.Shared;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


using System.Collections.Generic;
using System.Linq;



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


            public async Task<PostDto> UploadPdf(PostDto post)
        {
            var response = await HttpClient.PutAsJsonAsync("api/PostDefinition/pdf", post);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<PostDto>();
            }
            else return null;
        }

        public async Task<PostDto> Save(PostDto post)
        {
            var response = await HttpClient.PutAsJsonAsync(GetPostsUrl(), post);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<PostDto>();
            }
            else return null;
        }

        public async void DeletePost(int postId)
        {
            await HttpClient.DeleteAsync(GetPostUrlWithId(postId));
        }
    
           public async void DeletePdf(int postId)
        {
            await HttpClient.DeleteAsync(GetPostUrlWithId(postId));
        }
    }
}