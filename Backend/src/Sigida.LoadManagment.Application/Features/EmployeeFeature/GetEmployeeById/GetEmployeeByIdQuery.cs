﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Application.Features.ViewModels;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;

namespace Sigida.LoadManagment.Application.Features;

public sealed record GetEmployeeByIdQuery(Guid Id) 
    : IRequest<IResult<EmployeeViewModel>>;

public sealed class GetEmployeeByIdQueryHandler
    : IRequestHandler<GetEmployeeByIdQuery, IResult<EmployeeViewModel>>
{

    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEmployeeByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<IResult<EmployeeViewModel>> Handle(GetEmployeeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var employee = await _context.Set<Employee>()
            .Where(x => x.Id == request.Id)
            .Include(x => x.Position)
            .AsNoTracking().FirstOrDefaultAsync();

        if (employee is null)
            return Result<EmployeeViewModel>.Fail($"{request.Id} not found");

        var employeeView = _mapper.Map<Employee, EmployeeViewModel>(employee);

        return Result<EmployeeViewModel>.Success(employeeView);
    }
}
