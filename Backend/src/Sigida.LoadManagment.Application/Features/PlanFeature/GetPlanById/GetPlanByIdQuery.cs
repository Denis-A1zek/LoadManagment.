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

public sealed record GetPlanByIdQuery(Guid Id) : IRequest<IResult<PlanViewModel>>;

public sealed class GetPlanByIdQueryHandler
    : BaseHandler, IRequestHandler<GetPlanByIdQuery, IResult<PlanViewModel>>
{
    public GetPlanByIdQueryHandler
        (ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<IResult<PlanViewModel>> Handle(GetPlanByIdQuery request, CancellationToken cancellationToken)
    {
        var plan = await Context.Set<Plan>()
            .Where(x => x.Id == request.Id)
            .Include(x => x.Loads)
            .AsNoTracking().FirstOrDefaultAsync();

        if (plan is null)
            return Result<PlanViewModel>.Fail($"{request.Id} not found");

        var planView = Mapper.Map<Plan, PlanViewModel>(plan);

        return Result<PlanViewModel>.Success(planView);
    }
}
