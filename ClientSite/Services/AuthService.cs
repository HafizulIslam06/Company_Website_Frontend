using ClientSite.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;

namespace ClientSite.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly ITokenStorageService _tokenStorage;

        public AuthService(HttpClient http, ITokenStorageService tokenStorage)
        {
            _http = http;
            _tokenStorage = tokenStorage;
        }

        public async Task<bool> LoginAsync(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", request);
            if (!response.IsSuccessStatusCode)
                return false;

            var data = await response.Content.ReadFromJsonAsync<AuthResponse>();
            if (data is null) return false;

            await _tokenStorage.SaveTokenAsync(data.Token);
            return true;
        }

        public async Task LogoutAsync()
        {
            await _http.PostAsync("api/auth/logout", null);
            await _tokenStorage.RemoveTokenAsync();
        }

        public async Task<AuthResponse?> GetCurrentUserAsync()
        {
            var token = await _tokenStorage.GetTokenAsync();
            if (string.IsNullOrEmpty(token)) return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            // Adjust claim names safely
            var username = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name || c.Type == "unique_name")?.Value;
            var role = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role || c.Type == "role")?.Value;

            return new AuthResponse { Username = username ?? "", Role = role ?? "", Token = token };
        }
    }
}
