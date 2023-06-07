using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

public sealed record GetAllPlanLoadQuery(Guid Id) : IRequest<IResult<IEnumerable<PlanLoadViewModel>>>;

public sealed class GetAllPlanLoadQueryHandler 
    : BaseHandler, IRequestHandler<GetAllPlanLoadQuery, IResult<IEnumerable<PlanLoadViewModel>>>
{
    public GetAllPlanLoadQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper){}

    public async Task<IResult<IEnumerable<PlanLoadViewModel>>> 
        Handle(GetAllPlanLoadQuery request, CancellationToken cancellationToken)
    {
        var source = await Context.Set<Load>().Where(l => l.PlanId.Equals(request.Id))
            .Include(l => l.Subject)
            .Include(l => l.Specialty)
            .Include(l => l.SubjectSchedules)
            .ToListAsync();

        var planLoadsView = new List<PlanLoadViewModel>();

        source.ForEach(l => planLoadsView.Add(Mapper.Map<Load, PlanLoadViewModel>(l)));

        return Result<IEnumerable<PlanLoadViewModel>>.Success(planLoadsView);
    }
}
