using Microsoft.Extensions.DependencyInjection;
using Sigida.LoadManagment.Services.Implementations;
using Sigida.LoadManagment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddTransient<IEmployeeService, EmployeeService>()
            .AddTransient<IPositionsService, PositionsService>();
    }
}
