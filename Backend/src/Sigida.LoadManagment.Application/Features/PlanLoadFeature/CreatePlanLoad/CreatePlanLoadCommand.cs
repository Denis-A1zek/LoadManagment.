using AutoMapper;
using MediatR;
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
        IEnumerable<SubjectScheduleDto> subjectSchedule)
    {
        PlanId=planId;
        SpecialtyId=specialtyId;
        SubjectId=subjectId;
        SubjectSchedule=subjectSchedule;
    }

    public Guid PlanId { get; set; }
    public Guid SpecialtyId { get; init; }
    public Guid SubjectId { get; init; }
    public IEnumerable<SubjectScheduleDto> SubjectSchedule { get; set; }

}


public sealed class CreatePlanLoadCommandHandler 
    : BaseHandler, IRequestHandler<CreatePlanCommand, IResult<Guid>>
{
    public CreatePlanLoadCommandHandler
        (ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

    public Task<IResult<Guid>> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        //TO-DO
        throw new NotImplementedException();
    }
}