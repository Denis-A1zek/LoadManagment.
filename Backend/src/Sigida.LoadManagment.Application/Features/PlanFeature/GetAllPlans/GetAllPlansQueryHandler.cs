using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features.PlanFeature.GetAllPlans;

public sealed class GetAllPlansQueryHandler : IRequestHandler<GetAllPlansQuery, IResult<PlansResponse>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPlansQueryHandler(ApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<IResult<PlansResponse>> Handle(GetAllPlansQuery request, CancellationToken cancellationToken)
    {
        var source = _context.Plans.AsNoTracking()
            .Select(x => x)
            .Include(x => x.Loads);

        PlansResponse response = new(new List<PlanDetailsDto>());

        await source.ForEachAsync(s =>
        {
            var planDetails = _mapper.Map<Plan, PlanDetailsDto>(s);

            response.PlanDetails.Add(planDetails);
        });

        return Result<PlansResponse>.Success(response);
    }
}
