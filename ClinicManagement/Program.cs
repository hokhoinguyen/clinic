using ClinicManagement;
using ClinicManagement.Models;
using ClinicManagement.Services;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ClinicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicContext")));
builder.Services.AddScoped(x =>
{
    string CloudName = builder.Configuration["CloudinarySettings:CloudName"];
    string ApiKey = builder.Configuration["CloudinarySettings:ApiKey"];
    string ApiSecret = builder.Configuration["CloudinarySettings:ApiSecret"];
    return new Cloudinary(new Account(
        CloudName,
        ApiKey,
        ApiSecret));
});
builder.Services.AddScoped<BacSiService>();
builder.Services.AddScoped<YTaService>();
builder.Services.AddScoped<ThuocService>();
builder.Services.AddScoped<NguoiDungService>();
builder.Services.AddScoped<BenhNhanService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
