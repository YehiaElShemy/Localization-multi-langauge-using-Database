using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using whatssappnotificaion.Models.DataContext;
using whatssappnotificaion.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(option => 
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();//used during development to provide more detailed error pages with information about database-related errors.

builder.Services.AddLocalization();
builder.Services.AddScoped<ILangaugeService, LangaugeService>();
builder.Services.AddScoped<ILocalizationService, LocalizationService>();

//builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");
//builder.Services.AddRazorPages()
//    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
//    .AddDataAnnotationsLocalization();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var supportedCultures = new[] { "en", "ar","fr" };
var localizationOption = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOption);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseRequestLocalization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
