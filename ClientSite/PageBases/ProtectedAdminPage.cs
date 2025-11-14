using ClientSite.Models;
using ClientSite.Services;
using Microsoft.AspNetCore.Components;

namespace ClientSite.PageBases
{
    public class ProtectedAdminPage : ComponentBase
    {
        [Inject] protected AuthService AuthService { get; set; } = null!;
        [Inject] protected NavigationManager Nav { get; set; } = null!;

        protected AuthResponse? CurrentUser { get; private set; }
        protected bool IsLoaded { get; private set; } = false;
        protected bool IsAuthorized => CurrentUser != null && CurrentUser.Role == "Admin";

        protected override async Task OnInitializedAsync()
        {
            CurrentUser = await AuthService.GetCurrentUserAsync();
            IsLoaded = true;

            if (!IsAuthorized)
            {
                Nav.NavigateTo("/login", true);
            }
        }
    }
}
