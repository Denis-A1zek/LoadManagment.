using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;

namespace Sigida.LoadManagment.Application.Features;

public sealed class GetPositionsQueryHandler : IRequestHandler<GetPositionsQuery, IResult<IEnumerable<PositionDetails>>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPositionsQueryHandler(ApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<IResult<IEnumerable<PositionDetails>>> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
    {
        var positions = await _context.Set<Position>()
            .AsNoTracking()
            .Select(x 
                => _mapper.Map<Position, PositionDetails>(x))
            .ToListAsync();

        return Result<IEnumerable<PositionDetails>>.Success(positions);
    }
}
