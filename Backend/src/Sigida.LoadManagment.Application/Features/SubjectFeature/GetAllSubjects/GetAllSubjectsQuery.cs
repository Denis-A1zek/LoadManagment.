using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Application.Features.Base;
using Sigida.LoadManagment.Application.Features.ViewModels;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features;

public sealed record GetAllSubjectsQuery() : IRequest<IResult<IEnumerable<SubjectViewModel>>>;

public sealed class GetAllSubjectsQueryHandler 
    : BaseHandler, IRequestHandler<GetAllSubjectsQuery, IResult<IEnumerable<SubjectViewModel>>>
{
    public GetAllSubjectsQueryHandler
        (ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<IResult<IEnumerable<SubjectViewModel>>> Handle
        (GetAllSubjectsQuery request, CancellationToken cancellationToken)
    {
        var result = await Context.Set<Subject>()
            .AsNoTracking().ToListAsync(cancellationToken);

        var listSubjectView = new List<SubjectViewModel>();

        result.ForEach(specialty =>
        {
            listSubjectView.Add(Mapper.Map<Subject, SubjectViewModel>(specialty));
        });

        return Result<IEnumerable<SubjectViewModel>>.Success(listSubjectView);
    }
}
