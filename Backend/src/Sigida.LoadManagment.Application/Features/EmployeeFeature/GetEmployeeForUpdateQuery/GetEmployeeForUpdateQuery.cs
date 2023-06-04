using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Application.Features.Base;
using Sigida.LoadManagment.Application.Features.ViewModels;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features;

public sealed record GetEmployeeForUpdateQuery(Guid Id) 
    : IRequest<IResult<EmployeeEditViewModel>>;

public sealed class GetEmployeeForUpdateQueryHandler 
    : BaseHandler, IRequestHandler<GetEmployeeForUpdateQuery, IResult<EmployeeEditViewModel>>
{
    public GetEmployeeForUpdateQueryHandler
        (ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<IResult<EmployeeEditViewModel>> Handle
        (GetEmployeeForUpdateQuery request, CancellationToken cancellationToken)
    {
        var repository = Context.Set<Employee>();

        var seachingEmployee = await repository.FirstOrDefaultAsync(e => e.Id == request.Id);

        if (seachingEmployee is null)
            return Result<EmployeeEditViewModel>.Fail($"{request.Id} not found in the db");

        var employeeView = Mapper.Map<Employee, EmployeeEditViewModel>(seachingEmployee);

        return Result<EmployeeEditViewModel>.Success(employeeView);
    }
}
