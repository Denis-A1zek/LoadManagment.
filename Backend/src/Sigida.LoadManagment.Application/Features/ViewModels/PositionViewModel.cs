using AutoMapper;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features.ViewModels;

public sealed record PositionViewModel : IMapWith<Position>
{
    public int Id { get; init; }
    public string Title { get; init; } = null!;
    public string? LoadRange { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Position, PositionViewModel>()
            .ForMember(m => m.LoadRange, o => o.MapFrom(s => $"{s.MinLoad} - {s.MaxLoad}"));
    }
}
