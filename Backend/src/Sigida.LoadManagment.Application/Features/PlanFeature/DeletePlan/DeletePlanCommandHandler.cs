using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Infrastructure.Database;

namespace Sigida.LoadManagment.Application.Features;

public sealed class DeletePlanCommandHandler : IRequestHandler<DeletePlanCommand, IResult<Guid>>
{
    private readonly ApplicationDbContext _context;

    public DeletePlanCommandHandler (ApplicationDbContext context)
        => (_context) = (context);

    public async Task<IResult<Guid>> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
    {
        var plan = await _context.Plans.FirstOrDefaultAsync(
            p => p.Id == request.Id);

        if (plan is null)
            return Result<Guid>.Fail($"{request.Id} not found");

        _context.Plans.Remove(plan);
        await _context.SaveChangesAsync();

        return Result<Guid>.Success(plan.Id);
    }
}
