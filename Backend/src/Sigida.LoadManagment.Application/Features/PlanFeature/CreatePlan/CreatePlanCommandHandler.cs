using AutoMapper;
using MediatR;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features.PlanFeature.CreatePlan;

public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, IResult<Guid>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreatePlanCommandHandler
        (ApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<IResult<Guid>> Handle(CreatePlanCommand request, 
        CancellationToken cancellationToken)
    {
        var plan = _mapper.Map<Plan>(request);

        await _context.Plans.AddAsync(plan, cancellationToken);
        await _context.SaveChangesAsync();

        return Result<Guid>.Success(plan.Id);
    }
}
