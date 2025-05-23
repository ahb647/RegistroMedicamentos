global using Microsoft.EntityFrameworkCore;
global using RegistroMedicamentos.DAL;
global using RegistroMedicamentos.Models;
global using RegistroMedicamentos.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Options;
using RegistroMedicamentos.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddBlazorBootstrap();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();






builder.Services.AddDbContextFactory<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConStr"));
});




builder.Services.AddScoped<MedicamentosServices>();



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
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
