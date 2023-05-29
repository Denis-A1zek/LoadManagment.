using MediatR;
using Sigida.LoadManagment.Application.Features.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features;

public sealed record GetEmployeesPaginationQuery(int Page, int PageSize) 
    : IRequest<IResult<IEnumerable<EmployeeViewModel>>>;
