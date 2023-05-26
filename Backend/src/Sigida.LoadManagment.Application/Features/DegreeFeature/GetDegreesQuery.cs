using MediatR;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Application.Features.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features.DegreeFeature;

public sealed record GetDegreesQuery() : IRequest<IResult<IEnumerable<DegreeViewModel>>>;
