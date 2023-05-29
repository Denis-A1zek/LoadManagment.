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

namespace Sigida.LoadManagment.Application.Features;

public sealed class UpdateEmployeeCommandHandler 
    : IRequestHandler<UpdateEmployeeCommand, IResult<Guid>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateEmployeeCommandHandler(ApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<IResult<Guid>> Handle(UpdateEmployeeCommand request, 
        CancellationToken cancellationToken)
    {
        var employee = await _context.Set<Employee>()
            .Where(e => e.Id == request.Id).FirstOrDefaultAsync();

        if (employee is null)
            return Result<Guid>.Fail($"{request.Id} not found");

        employee.Name = request.Name;
        employee.Surname = request.Surname;
        employee.Lastname = request.Lastname;
        employee.PositionId = request.PositionId;
        var newEmployee = _context.Set<Employee>().Update(employee);
            

        if (newEmployee is null)
            return Result<Guid>.Fail($"Не удалось обновить {request.Id}");

        return Result<Guid>.Success(request.Id);
    }
}
