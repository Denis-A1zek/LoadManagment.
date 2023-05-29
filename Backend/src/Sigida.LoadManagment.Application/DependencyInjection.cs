using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));

        services.AddAutoMapper(
            cfg => cfg.AddProfile(new AssemblyMappingProfile(typeof(IMapWith<>).Assembly)));

        return services;
    }
}
