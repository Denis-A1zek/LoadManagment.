using MediatR;

namespace Sigida.LoadManagment.Application.Features.PlanFeature.GetAllPlans;

public record GetAllPlansQuery() : IRequest<IResult<PlansResponse>>;

