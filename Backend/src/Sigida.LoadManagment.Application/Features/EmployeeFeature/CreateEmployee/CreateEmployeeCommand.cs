using AutoMapper;
using MediatR;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Application.Features.Base;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features;

public sealed record CreateEmployeeCommand
    (string Name, string Surname, string Lastname, Guid PositionId)
    : IRequest<IResult<Guid>>;

public sealed class CreateEmployeeCommandHandler
    :BaseHandler ,IRequestHandler<CreateEmployeeCommand, IResult<Guid>>
{
    public CreateEmployeeCommandHandler(ApplicationDbContext context) : base(context) { }

    public async Task<IResult<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee()
        {
            Name = request.Name,
            Lastname = request.Lastname,
            Surname = request.Surname,
            PositionId = request.PositionId
        };

        await Context.Set<Employee>().AddAsync(employee);
        await Context.SaveChangesAsync();

        return Result<Guid>.Success(employee.Id);
    }
}
