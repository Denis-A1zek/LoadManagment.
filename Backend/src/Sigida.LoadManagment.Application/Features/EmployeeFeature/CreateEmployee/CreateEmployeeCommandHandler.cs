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

namespace Sigida.LoadManagment.Application.Features;

public sealed class CreateEmployeeCommandHandler
    : IRequestHandler<CreateEmployeeCommand, IResult<Guid>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandler
        (ApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<IResult<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee()
        {
            Name = request.Name,
            Lastname = request.Lastname,
            Surname = request.Surname,
            DegreeId = request.DegreeId,
            PositionId = request.PositionId
        };

        await _context.Set<Employee>().AddAsync(employee);
        await _context.SaveChangesAsync();

        return Result<Guid>.Success(employee.Id);
    }
}
