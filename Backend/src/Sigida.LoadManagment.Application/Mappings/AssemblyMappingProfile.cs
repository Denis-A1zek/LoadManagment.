using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Mappings;

public sealed class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly)
        => ApplyMappingsFromAssembly(assembly);

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces()
            .Any(i => i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IMapWith<>))).ToList();

        types.ForEach(type =>
        {
            var instance = Activator.CreateInstance(type);
            var methodeInfo = type.GetMethod("Mapping");
            methodeInfo?.Invoke(instance, new object[] { this });
        });
    }
}
