using SocialMedia.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SocialMediaContext>(options => 
{
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler("/Home/Error");
}

app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=index}/{id}");

app.Run();
