using Microsoft.Extensions.FileProviders;
using $ext_safeprojectname$SharedUI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles(new StaticFileOptions
{
  FileProvider = new CompositeFileProvider(builder.Environment.WebRootFileProvider, new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"..\$ext_safeprojectname$SharedUI\wwwroot")))
});

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
