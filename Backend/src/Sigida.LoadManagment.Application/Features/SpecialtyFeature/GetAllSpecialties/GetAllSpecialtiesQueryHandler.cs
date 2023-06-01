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

public sealed class GetAllSpecialtiesQueryHandler 
    : BaseHandler, IRequestHandler<GetAllSpecialtiesQuery, IResult<IEnumerable<SpecialtyViewModel>>>
{
    public GetAllSpecialtiesQueryHandler
        (ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<IResult<IEnumerable<SpecialtyViewModel>>> Handle(
        GetAllSpecialtiesQuery request, CancellationToken cancellationToken)
    {
        var result = await Context.Set<Specialty>()
            .AsNoTracking().ToListAsync(cancellationToken);

        var listSpecialtiesView = new List<SpecialtyViewModel>();

        result.ForEach(specialty =>
        {
            listSpecialtiesView.Add(Mapper.Map<Specialty,SpecialtyViewModel>(specialty));
        });

        return Result<IEnumerable<SpecialtyViewModel>>.Success(listSpecialtiesView);
    }
}
