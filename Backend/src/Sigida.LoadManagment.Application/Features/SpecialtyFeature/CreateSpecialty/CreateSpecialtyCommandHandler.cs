using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;

namespace Sigida.LoadManagment.Application.Features;

public sealed class CreateSpecialtyCommandHandler
    : IRequestHandler<CreateSpecialtyCommand, IResult<Guid>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateSpecialtyCommandHandler
        (ApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<IResult<Guid>> Handle(CreateSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var specialtyInDb = await _context.Set<Specialty>()
            .Where(s => s.Code.Equals(request.Code))
            .FirstOrDefaultAsync();

        if (specialtyInDb is not null)
            Result<Guid>.Fail($"Запись уже существует {specialtyInDb.Id}");

        var specialty = new Specialty()
        {
            Code = request.Code,
            Name = request.Name
        };

        await _context.AddAsync(specialty);
        await _context.SaveChangesAsync();

        return Result<Guid>.Success(specialty.Id);
    }
}
