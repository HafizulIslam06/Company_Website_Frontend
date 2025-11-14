namespace ClientSite.Services
{
    public interface ITokenStorageService
    {
        Task SaveTokenAsync(string token);
        Task<string?> GetTokenAsync();
        Task RemoveTokenAsync();
    }
}
