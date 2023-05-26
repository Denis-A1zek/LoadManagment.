using MediatR;

namespace Sigida.LoadManagment.Application.Features;

public record GetAllPlansQuery() : IRequest<IResult<PlansResponse>>;

