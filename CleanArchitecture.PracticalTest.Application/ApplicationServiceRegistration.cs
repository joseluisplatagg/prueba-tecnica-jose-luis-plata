using System.Globalization;
using CleanArchitecture.PracticalTest.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.PracticalTest.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Agregamos el uso de AutoMapper, MediatR y FluentValidation
        services.AddAutoMapper(typeof(ApplicationServiceRegistration).Assembly);
        services.AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));

        // Agregamos el comportamiento de las excepciones
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
        // Agregamos el comportamiento de las validaciones
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        

        return services;
    }
}
