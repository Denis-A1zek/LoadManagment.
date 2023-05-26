using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sigida.LoadManagment.Unit;

public static class FictitiosFactory
{
    private static ApplicationDbContext _context;
    public static ApplicationDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "Planning")
        .Options;

        _context = new ApplicationDbContext(options);
        return _context;
    }

    public static IMapper CreateMapper()
    {
        var mapperConfig = new MapperConfiguration(o =>
        {
            o.AddProfile(new AssemblyMappingProfile(typeof(IMapWith<>).Assembly));
        });

        return new Mapper(mapperConfig);
    }

    public static void Dispose()
    {
        _context.Database.EnsureDeleted();
    }
}
