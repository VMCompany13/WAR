using Microsoft.EntityFrameworkCore;
using WebApService;
using WebApService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddNewtonsoftJson();


/*builder.Services.AddDbContext<TestDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TestDbConnection")));*/


builder.Services.RegisteredWebApiServices();

//builder.Services.RegTransient<IUsersService, UsersService>();

//builder.Services.AddTransient<IUsersService, UsersService>();

var app = builder.Build();

//app.MapGet("/users", (TestDbContext db) => db.Users.ToList());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");


app.MapFallbackToFile("index.html"); ;

app.Run();
