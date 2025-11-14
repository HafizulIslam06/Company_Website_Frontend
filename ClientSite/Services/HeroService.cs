using ClientSite.Models;
using System.Net.Http.Json;

namespace ClientSite.Services
{
    public class HeroService
    {
        private readonly HttpClient _http;

        public HeroService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<HeroSection>> GetHeroesAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<HeroSection>>("api/HeroSection");
            }
            catch
            {
                return new List<HeroSection>(); // fallback
            }
        }
    }
}
