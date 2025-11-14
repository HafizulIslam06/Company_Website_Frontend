using ClientSite.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace ClientSite.Services
{
    public class AboutService
    {
        private readonly HttpClient _http;

        public AboutService(HttpClient http)
        {
            _http = http;
        }

        // Get all about sections
        public async Task<List<AboutSection>> GetAboutSectionsAsync()
        {
            try
            {
                // Return empty list if API returns null
                return await _http.GetFromJsonAsync<List<AboutSection>>("api/AboutSection") ?? new List<AboutSection>();
            }
            catch
            {
                // Handle errors gracefully
                return new List<AboutSection>();
            }
        }

        // Get a single about section by ID
        public async Task<AboutSection?> GetAboutSectionByIdAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<AboutSection>($"api/AboutSection/{id}");
            }
            catch
            {
                return null;
            }
        }

        // Add new about section
        public async Task<HttpResponseMessage> AddAboutSectionAsync(AboutSection section)
        {
            return await _http.PostAsJsonAsync("api/AboutSection", section);
        }

        // Update existing about section
        public async Task<HttpResponseMessage> UpdateAboutSectionAsync(int id, AboutSection section)
        {
            return await _http.PutAsJsonAsync($"api/AboutSection/{id}", section);
        }

        // Delete about section
        public async Task<HttpResponseMessage> DeleteAboutSectionAsync(int id)
        {
            return await _http.DeleteAsync($"api/AboutSection/{id}");
        }
    }
}
