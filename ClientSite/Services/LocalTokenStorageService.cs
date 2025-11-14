using Microsoft.JSInterop;

namespace ClientSite.Services
{
    public class LocalTokenStorageService : ITokenStorageService
    {
        private readonly IJSRuntime _js;

        public LocalTokenStorageService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task SaveTokenAsync(string token) =>
            await _js.InvokeVoidAsync("localStorage.setItem", "jwt", token);

        public async Task<string?> GetTokenAsync() =>
            await _js.InvokeAsync<string?>("localStorage.getItem", "jwt");

        public async Task RemoveTokenAsync() =>
            await _js.InvokeVoidAsync("localStorage.removeItem", "jwt");
    }
}
