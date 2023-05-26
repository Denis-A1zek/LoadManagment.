using AutoMapper;
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

namespace Sigida.LoadManagment.Application.Features.DegreeFeature;

public sealed class GetDegreesQueryHandler 
    : IRequestHandler<GetDegreesQuery, IResult<IEnumerable<DegreeViewModel>>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDegreesQueryHandler(ApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<IResult<IEnumerable<DegreeViewModel>>> Handle
        (GetDegreesQuery request, CancellationToken cancellationToken)
    {
        var degrees = await _context.Set<Degree>().AsNoTracking()
            .Select(d => _mapper.Map<DegreeViewModel>(d))
            .ToListAsync();


        return Result<IEnumerable<DegreeViewModel>>.Success(degrees);
    }
}
