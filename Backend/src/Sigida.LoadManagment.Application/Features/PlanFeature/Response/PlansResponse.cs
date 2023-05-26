using Sigida.LoadManagment.Application.Common.Models;

namespace Sigida.LoadManagment.Application.Features;

public sealed record PlansResponse(List<PlanDetails> PlanDetails);
