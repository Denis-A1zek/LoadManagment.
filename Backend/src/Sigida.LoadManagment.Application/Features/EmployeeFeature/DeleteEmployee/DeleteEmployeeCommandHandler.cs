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

namespace Sigida.LoadManagment.Application.Features;

public sealed class DeleteEmployeeCommandHandler 
    : IRequestHandler<DeleteEmployeeCommand, IResult<Guid>>
{
    private readonly ApplicationDbContext _context;

    public DeleteEmployeeCommandHandler(ApplicationDbContext context)
        => (_context) = (context);

    public async Task<IResult<Guid>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var exsisEmployee = await _context.Set<Employee>()
            .FirstOrDefaultAsync(e => e.Id == request.Id);

        if (exsisEmployee is null)
            return Result<Guid>.Fail($"{request.Id} not found");

        _context.Set<Employee>().Remove(exsisEmployee);
        await _context.SaveChangesAsync();

        return Result<Guid>.Success(exsisEmployee.Id);
    }
}
