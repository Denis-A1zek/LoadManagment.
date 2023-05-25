using AutoMapper;
using Sigida.LoadManagment.Application.Features.PlanFeature.CreatePlan;
using Sigida.LoadManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Mappings;

public sealed class PlanMapperConfiguration : Profile
{
    public PlanMapperConfiguration()
    {
        CreateMapForCreatePlanCommand();
    }

    private void CreateMapForCreatePlanCommand()
    {
        CreateMap<CreatePlanCommand, Plan>()
            .ForMember(m => m.Start, o => o.MapFrom(s => s.StartDate))
            .ForMember(m => m.End, o => o.MapFrom(s => s.EndDate))
            .ReverseMap();
    }
}
