using Sigida.LoadManagment.Application.Common.Models;

namespace Sigida.LoadManagment.Application.Features.PlanFeature;

public sealed record PlansResponse(List<PlanDetailsDto> PlanDetails);
