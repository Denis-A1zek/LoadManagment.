using MediatR;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Application.Features.ViewModels;

namespace Sigida.LoadManagment.Application.Features;

public record GetAllPlansQuery() : IRequest<IResult<IEnumerable<PlanViewModel>>>;

