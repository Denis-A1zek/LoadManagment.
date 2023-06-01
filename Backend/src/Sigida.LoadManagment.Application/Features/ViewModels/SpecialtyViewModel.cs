using AutoMapper;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Domain.Entities;

namespace Sigida.LoadManagment.Application.Features.ViewModels;

public sealed record SpecialtyViewModel : IMapWith<Specialty>
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Specialty, SpecialtyViewModel>().ReverseMap();
    }
}
