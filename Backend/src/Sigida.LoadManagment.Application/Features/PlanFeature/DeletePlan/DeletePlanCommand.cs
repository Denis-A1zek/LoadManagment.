using MediatR;
using Sigida.LoadManagment.Application.Common.Models;

namespace Sigida.LoadManagment.Application.Features.PlanFeature.DeletePlan;

public sealed record DeletePlanCommand(Guid Id) : IRequest<IResult<Guid>>;

