using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ClientSite.Models;
using System.Collections.Generic;
using System;

namespace ClientSite.Services
{
    public class BlogService
    {
        private readonly HttpClient _httpClient;

        // Constructor injection
        public BlogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BlogPost>> GetAllBlogsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<BlogPost>>("api/BlogPosts")
                       ?? new List<BlogPost>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching blogs: {ex.Message}");
                return new List<BlogPost>();
            }
        }

        public async Task<BlogPost?> CreateBlogAsync(BlogPost blog)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/BlogPosts", blog);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<BlogPost>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating blog: {ex.Message}");
            }
            return null;
        }

        public async Task<bool> UpdateBlogAsync(int id, BlogPost blog)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/BlogPosts/{id}", blog);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating blog: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/BlogPosts/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting blog: {ex.Message}");
                return false;
            }
        }
    }
}
