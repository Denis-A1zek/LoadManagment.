using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sigida.LoadManagment.Application.Common.Behaviors;
using Sigida.LoadManagment.Application.Mappings;
using System.Reflection;

namespace Sigida.LoadManagment.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));

        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        services.AddAutoMapper(
            cfg => cfg.AddProfile(new AssemblyMappingProfile(typeof(IMapWith<>).Assembly)));

        return services;
    }
}
