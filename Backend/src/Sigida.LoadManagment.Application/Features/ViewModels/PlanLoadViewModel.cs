using AutoMapper;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features.ViewModels;

public record PlanLoadViewModel : IMapWith<Load>
{
    public Guid Id { get; set; }
    public Guid PlanId { get; set; }
    public Guid SubjectId { get; set; }
    public string SubjectCode { get; set; }
    public string SubjectName { get; set; }
    public Guid SpecialtyId { get; set; }
    public string SpecialtyCode { get; set;}
    public string SpecialtyName { get; set; }
    public IEnumerable<SubjectSchedule> SubjectSchedules { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Load, PlanLoadViewModel>()
            .ForMember(pl => pl.SpecialtyCode, o => o.MapFrom(s => s.Specialty!.Code))
            .ForMember(pl => pl.SpecialtyName, o => o.MapFrom(s => s.Specialty!.Name))
            .ForMember(pl => pl.SubjectCode, o => o.MapFrom(s => s.Subject!.Code))
            .ForMember(pl => pl.SubjectName, o => o.MapFrom(s => s.Subject!.Name))
            .ForMember(pl => pl.SubjectSchedules, o => o.MapFrom(s => s.SubjectSchedules ?? new List<SubjectSchedule>()))
            .ForMember(pl => pl.PlanId, o => o.MapFrom(s => s.PlanId));
    }
}
