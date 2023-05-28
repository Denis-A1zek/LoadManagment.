using AutoMapper;
using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Application.Features.ViewModels;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features;

public sealed class GetAllPlansQueryHandler 
    : IRequestHandler<GetAllPlansQuery, IResult<IEnumerable<PlanViewModel>>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPlansQueryHandler(ApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<IResult<IEnumerable<PlanViewModel>>> Handle(GetAllPlansQuery request, CancellationToken cancellationToken)
    {
        var source = _context.Plans.AsNoTracking()
            .Select(x => x)
            .Include(x => x.Loads);

        var response = new List<PlanViewModel>(new List<PlanViewModel>());

        await source.ForEachAsync(s =>
        {
            var planDetails = _mapper.Map<Plan, PlanViewModel>(s);

            response.Add(planDetails);
        });

        return Result<IEnumerable<PlanViewModel>>.Success(response);
    }
}
