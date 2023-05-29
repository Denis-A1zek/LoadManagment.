using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features;

public sealed record CreateEmployeeCommand
    (string Name, string Surname, string Lastname, Guid PositionId)
    : IRequest<IResult<Guid>>;
