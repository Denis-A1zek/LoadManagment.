using MediatR;
using Sigida.LoadManagment.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features.PlanFeature.CreatePlan;

public sealed record CreatePlanCommand : IRequest<IResult<Guid>>
{
    public CreatePlanCommand(string description,
        DateTime? startDate = null,
        DateTime? endDate = null)
    {
        Description = description;
        StartDate = startDate ?? new DateTime(DateTime.Now.Year, 09, 1);
        EndDate = endDate ?? StartDate.Value.AddMonths(10);
    }

    public string Description { get; init; } = null!;
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}
