using MediatR;
using Sigida.LoadManagment.Application.Common.Models;

namespace Sigida.LoadManagment.Application.Features;

public sealed record DeletePlanCommand(Guid Id) : IRequest<IResult<Guid>>;

