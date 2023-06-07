using AutoMapper;
using MediatR;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Application.Features.Base;
using Sigida.LoadManagment.Application.Features.ViewModels;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features;

public sealed record CreatePlanLoadCommand : IRequest<IResult<Guid>>
{
    public CreatePlanLoadCommand
        (Guid planId, Guid specialtyId, Guid subjectId, 
        IEnumerable<SubjectScheduleDto> subjectSchedules)
    {
        PlanId=planId;
        SpecialtyId=specialtyId;
        SubjectId=subjectId;
        SubjectSchedules=subjectSchedules;
    }

    public Guid PlanId { get; set; }
    public Guid SpecialtyId { get; init; }
    public Guid SubjectId { get; init; }
    public IEnumerable<SubjectScheduleDto> SubjectSchedules { get; set; }

}


public sealed class CreatePlanLoadCommandHandler 
    : BaseHandler, IRequestHandler<CreatePlanLoadCommand, IResult<Guid>>
{
    public CreatePlanLoadCommandHandler
        (ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<IResult<Guid>> Handle(CreatePlanLoadCommand request, CancellationToken cancellationToken)
    {
        var subjectSchedules = new List<SubjectSchedule>();

        foreach (var subjectSchedule in request.SubjectSchedules)
        {
            subjectSchedules.Add(Mapper.Map<SubjectScheduleDto, SubjectSchedule>(subjectSchedule));
        }

        var load = new Load()
        {
            PlanId = request.PlanId,
            SpecialtyId = request.SpecialtyId,
            SubjectId = request.SubjectId,
            SubjectSchedules = subjectSchedules
        };

        await Context.Set<Load>().AddAsync(load);
        await Context.SaveChangesAsync();

        return Result<Guid>.Success(load.Id);
    }
}