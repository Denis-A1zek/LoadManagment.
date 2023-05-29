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

public sealed class GetAllEmployeeQueryHandler
    : IRequestHandler<GetAllEmployeeQuery, IResult<IEnumerable<EmployeeViewModel>>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllEmployeeQueryHandler(ApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<IResult<IEnumerable<EmployeeViewModel>>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employees = _context.Set<Employee>()
            .Include(e => e.Position)
            .AsNoTracking().AsQueryable();

        if (!employees.Any()) 
        {
            return Result<IEnumerable<EmployeeViewModel>>.Success(Enumerable.Empty<EmployeeViewModel>());
        }

        var employeesView = new List<EmployeeViewModel>();

        await employees.ForEachAsync(e =>
            employeesView.Add(_mapper.Map<Employee, EmployeeViewModel>(e))
        );
        
        return Result<IEnumerable<EmployeeViewModel>>.Success(employeesView);
    }
}
