using WebApService.Services;

namespace WebApService;

public static class WebApiServiceDependencyInstaller
{
    public static void RegisteredWebApiServices(this IServiceCollection services)
    {
        RegTransient(services);
        RegScoped(services);
        RegSingleton(services);
    }

    private static void RegSingleton(IServiceCollection services)
    {
        //services.AddSingleton<>()
    }

    private static void RegScoped(IServiceCollection services)
    {
        //services.AddScoped<>()
    }

    private static void RegTransient(IServiceCollection services)
    {
        services.AddTransient<IUsersService, UsersService>();
    }
}