using AutoMapper;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Common.Models;

public sealed record PlanDetails : IMapWith<Plan>
{
    public Guid Id { get; init; }
    public string Description { get; init; }
    public int LoadCount { get; init; }
    public string Period { get; init; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Plan, PlanDetails>()
            .ForMember(m => m.Id,
                o => o.MapFrom(s => s.Id))
            .ForMember(m => m.LoadCount,
                o => o.MapFrom(s => s.Loads.Count))
            .ForMember(m => m.Period,
                o => o.MapFrom(s => $"{s.Start.ToShortDateString()}-{s.End.ToShortDateString()}"));
    }
}
