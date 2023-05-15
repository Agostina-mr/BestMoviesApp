using BestMoviesApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);
builder
    .Services.AddRazorPages()
    .Services.AddServerSideBlazor()
    .Services.AddScoped<IMovieService, MovieService>()
    .AddHttpClient<IMovieService, MovieService>(client =>
    {
        client.BaseAddress = new Uri("https://localhost:7175/");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();