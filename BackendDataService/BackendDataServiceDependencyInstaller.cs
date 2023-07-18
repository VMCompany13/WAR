using BackendDataService.DataBase;
using BackendDataService.DataBase.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BackendDataService;

public static class BackendDataServiceDependencyInstaller
{
    public static void RegisteredBackendServices(this IServiceCollection services)
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
        services.AddTransient<IUserDataWriter, UsersDataWriter>();
        services.AddTransient<IUserDataReader, UsersDataReader>();
    }
}