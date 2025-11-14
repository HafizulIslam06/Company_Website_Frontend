using ClientSite;
using ClientSite.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Register HttpClient to point to your backend API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7099/") // your backend base URL
});
//Registration Services
builder.Services.AddScoped<HeroService>();
builder.Services.AddScoped<BlogService>();
builder.Services.AddScoped<AboutService>();
builder.Services.AddScoped<TeamMemberService>();
builder.Services.AddScoped<ITokenStorageService, LocalTokenStorageService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();


builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
