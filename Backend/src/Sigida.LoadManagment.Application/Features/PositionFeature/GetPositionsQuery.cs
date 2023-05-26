using MediatR;
using Sigida.LoadManagment.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features;

public sealed record GetPositionsQuery() : IRequest<IResult<IEnumerable<PositionDetails>>>;
