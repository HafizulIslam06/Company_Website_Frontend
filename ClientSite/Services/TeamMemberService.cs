using ClientSite.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ClientSite.Services
{
    public class TeamMemberService
    {
        private readonly HttpClient _http;

        public TeamMemberService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TeamMember>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<TeamMember>>("api/TeamMembers")
                   ?? new List<TeamMember>();
        }

        public async Task<bool> CreateAsync(TeamMember member, Stream? photoStream, string? photoFileName)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(member.Name ?? ""), "Name");
            form.Add(new StringContent(member.Role ?? ""), "Role");
            form.Add(new StringContent(member.Bio ?? ""), "Bio");
            form.Add(new StringContent(member.FacebookUrl ?? ""), "FacebookUrl");
            form.Add(new StringContent(member.InstagramUrl ?? ""), "InstagramUrl");
            form.Add(new StringContent(member.LinkedInUrl ?? ""), "LinkedInUrl");
            form.Add(new StringContent(member.GitHubUrl ?? ""), "GitHubUrl");

            if (photoStream != null)
            {
                var streamContent = new StreamContent(photoStream);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                form.Add(streamContent, "photo", photoFileName);
            }

            var res = await _http.PostAsync("api/TeamMembers", form);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(TeamMember member, Stream? photoStream, string? photoFileName)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(member.Id.ToString()), "Id");
            form.Add(new StringContent(member.Name ?? ""), "Name");
            form.Add(new StringContent(member.Role ?? ""), "Role");
            form.Add(new StringContent(member.Bio ?? ""), "Bio");
            form.Add(new StringContent(member.FacebookUrl ?? ""), "FacebookUrl");
            form.Add(new StringContent(member.InstagramUrl ?? ""), "InstagramUrl");
            form.Add(new StringContent(member.LinkedInUrl ?? ""), "LinkedInUrl");
            form.Add(new StringContent(member.GitHubUrl ?? ""), "GitHubUrl");

            if (photoStream != null)
            {
                var streamContent = new StreamContent(photoStream);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                form.Add(streamContent, "photo", photoFileName);
            }

            var res = await _http.PutAsync($"api/TeamMembers/{member.Id}", form);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await _http.DeleteAsync($"api/TeamMembers/{id}");
            return res.IsSuccessStatusCode;
        }
    }
}

