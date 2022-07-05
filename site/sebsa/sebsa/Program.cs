using Microsoft.EntityFrameworkCore;
using sebsa.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var startServer = builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Database>(options =>
    options.UseNpgsql("Host=sebsa.covoattbbrhu.sa-east-1.rds.amazonaws.com;Port=5432;Database=sebsa;User Id=postgres;Password=12345678"));


builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication("Identity.Login")
    .AddCookie("Identity.Login", config =>
    {
        config.Cookie.Name = "Identity.Login";
        config.LogoutPath = "/Login";
        config.AccessDeniedPath = "/Login";
        config.ExpireTimeSpan = TimeSpan.FromMinutes(15);
     });

var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    /*pattern: "{controller=ValidationLogin}/{action=Index}/{id?}");*/
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
