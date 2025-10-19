using Microsoft.Extensions.DependencyInjection;
using MongoFramework;
using mvc_mongodb.Data; // AppDbContext burada tanýmlý olmalý
using mvc_mongodb.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<AppDbContext>(provider =>
{
    var connection = MongoDbConnection.FromConnectionString("mongodb://localhost:27017/mvc_mongodb");
    return new AppDbContext(connection);
});





builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Varsayýlan route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Departman}/{action=Index}/{id?}");

app.Run();
