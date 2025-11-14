using ClientSite.Models;
using System.Net.Http.Json;

namespace ClientSite.Services
{
    public class UserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<UserModel>?> GetUsersAsync()
        {
            return await _http.GetFromJsonAsync<List<UserModel>>("api/user");
        }

        public async Task<UserModel?> GetUserAsync(int id)
        {
            return await _http.GetFromJsonAsync<UserModel>($"api/user/{id}");
        }

        public async Task CreateUserAsync(UserModel user)
        {
            await _http.PostAsJsonAsync("api/user", user);
        }

        public async Task UpdateUserAsync(int id, UserModel user)
        {
            await _http.PutAsJsonAsync($"api/user/{id}", user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _http.DeleteAsync($"api/user/{id}");
        }
    }
}
