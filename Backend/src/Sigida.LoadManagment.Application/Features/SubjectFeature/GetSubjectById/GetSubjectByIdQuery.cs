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

public sealed record GetSubjectByIdQuery(Guid Id) : IRequest<IResult<SubjectViewModel>>;

public sealed class GetSubjectByIdQueryHandler 
    : BaseHandler, IRequestHandler<GetSubjectByIdQuery, IResult<SubjectViewModel>>
{
    public GetSubjectByIdQueryHandler
        (ApplicationDbContext context, IMapper mapper) : base(context, mapper){}

    public async Task<IResult<SubjectViewModel>> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
    {
        
        var searchingSubject = await Context.Set<Subject>().
                                    FirstOrDefaultAsync(s => s.Id == request.Id);

        if (searchingSubject is null)
            return Result<SubjectViewModel>.Fail($"{request.Id} not found in the db");

        var subjectView = Mapper.Map<Subject, SubjectViewModel>(searchingSubject);

        return Result<SubjectViewModel>.Success(subjectView);
    }
}
