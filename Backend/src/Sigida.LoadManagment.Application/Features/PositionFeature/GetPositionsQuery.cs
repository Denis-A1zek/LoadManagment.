using MediatR;
using Sigida.LoadManagment.Application.Features.ViewModels;

namespace Sigida.LoadManagment.Application.Features;

public sealed record GetPositionsQuery() : IRequest<IResult<IEnumerable<PositionViewModel>>>;
