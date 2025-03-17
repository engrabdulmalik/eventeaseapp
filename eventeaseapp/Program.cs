using eventeaseapp.Services;
using eventeaseapp.Components; // Add this line to include the namespace for the App component

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register UserSessionService
builder.Services.AddScoped<UserSessionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<eventeaseapp.Components.App>() // Ensure the correct namespace is used here
    .AddInteractiveServerRenderMode();

app.Run();