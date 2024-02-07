using FerreteriaApp.Models;
using FerreteriaApp.Validations;
using FluentValidation;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add validator services to Ferreterias model
builder.Services.AddScoped<IValidator<FerreteriaModel>, FerreteriasValidator>();

// Add validator services to Product model
builder.Services.AddScoped<IValidator<ProductModel>, ProductValidator>();

ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("es");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
