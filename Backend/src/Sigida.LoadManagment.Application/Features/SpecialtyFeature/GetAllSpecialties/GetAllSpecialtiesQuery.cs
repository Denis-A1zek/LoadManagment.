using MediatR;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Application.Features.ViewModels;

namespace Sigida.LoadManagment.Application.Features;

public sealed record GetAllSpecialtiesQuery() 
    : IRequest<IResult<IEnumerable<SpecialtyViewModel>>>;
