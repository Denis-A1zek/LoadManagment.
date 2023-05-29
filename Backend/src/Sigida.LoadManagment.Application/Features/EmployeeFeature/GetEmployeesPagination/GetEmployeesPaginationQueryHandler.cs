using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Application.Features.ViewModels;
using Sigida.LoadManagment.Application.Helpers;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features;

public sealed class GetEmployeesPaginationQueryHandler
    : IRequestHandler<GetEmployeesPaginationQuery, 
        IResult<PageViewModel<EmployeeViewModel>>>
{

    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEmployeesPaginationQueryHandler
        (ApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<IResult<PageViewModel<EmployeeViewModel>>> Handle
        (GetEmployeesPaginationQuery request, CancellationToken cancellationToken)
    {
        var employeeCount = await _context.Set<Employee>().CountAsync();
        var totalPages = Pagination.CalculateNumberOfPages(employeeCount, request.PageSize);
        var skipValues = Pagination.CalculateNumberOfSkips(request.Page, request.PageSize);

        var employee = await _context.Set<Employee>()
            .Skip(skipValues)
            .Take(request.PageSize)
            .Select(e => _mapper.Map<Employee, EmployeeViewModel>(e))
            .ToListAsync();

        var employeePage = new PageViewModel<EmployeeViewModel>(employee, employeeCount,totalPages);

        return Result<PageViewModel<EmployeeViewModel>>.Success(employeePage);
    }
}
