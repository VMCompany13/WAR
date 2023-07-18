using BackendDataService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

//        builder.Services.AddControllersWithViews().AddNewtonsoftJson();
        builder.Services.AddRazorPages();
        builder.Services.AddControllers();

        builder.Configuration.AddJsonFile("C://source//WebApiReact//BackendDataService//appsettings.json");

        builder.Services.RegisteredBackendServices();


        builder.Services.AddDbContext<TestDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("TestDbConnection")));

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

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
        });

        app.Run();
    }
}