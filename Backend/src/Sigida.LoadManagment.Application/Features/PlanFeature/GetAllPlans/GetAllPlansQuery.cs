using MediatR;
using Sigida.LoadManagment.Application.Common.Models;

namespace Sigida.LoadManagment.Application.Features;

public record GetAllPlansQuery() : IRequest<IResult<IEnumerable<PlanDetails>>>;

