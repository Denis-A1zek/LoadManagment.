using AutoMapper;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features.ViewModels;

public record EmployeeViewModel : IMapWith<Employee>
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string PositionName { get; set; }
    public string Load { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Employee, EmployeeViewModel>()
            .ForMember(m => m.FullName, 
                o => o.MapFrom(src => $"{src.Surname} {src.Name} {src.Lastname}"))
            .ForMember(m => m.PositionName,
                o => o.MapFrom(src => $"{src.Position.Title}"))
            .ForMember(m => m.Load,
                o => o.MapFrom(src => $"{src.Position.MinLoad} - {src.Position.MaxLoad}"));
    }
}
