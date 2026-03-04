using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;
using CleanArchitecture.PracticalTest.Application.Contracts.Data;
using CleanArchitecture.PracticalTest.Domain.Interfaces;
using CleanArchitecture.PracticalTest.Infrastructure.Data;
using CleanArchitecture.PracticalTest.Infrastructure.Data.Repositories;
using CleanArchitecture.PracticalTest.Infrastructure.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;


namespace CleanArchitecture.PracticalTest.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContextDb>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ContextDb")!,
            b => b.MigrationsAssembly("CleanArchitecture.PracticalTest.Infrastructure"))
                .UseSnakeCaseNamingConvention() // Convierte nombres de tablas y columnas a snake_case
                .EnableSensitiveDataLogging() // Para ver los valores de las consultas en la consola
                .AddInterceptors(new PaqueteEstatusInterceptor())
        );

        // Repositorios, UnitOfWork y QueryStores
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Configuración de la internacionalización para los mensajes.
        services.AddLocalization();

        var supportedCultures = new[]
        {
            new CultureInfo("es-MX"),
            new CultureInfo("en-US")
        };

        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture("es-MX");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });

        services.AddSingleton<ILocalizer, Localizer>();

        return services;
    }
}