using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Application.Features.Base;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features;

public sealed record UpdateSubjectCommand(Guid Id, string Code, string Name) : IRequest<IResult<Unit>>;

public sealed class UpdateSubjectCommandHandler 
    : BaseHandler ,IRequestHandler<UpdateSubjectCommand, IResult<Unit>>
{
    public UpdateSubjectCommandHandler(ApplicationDbContext context) : base(context) { }

    public async Task<IResult<Unit>> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = await Context.Set<Subject>()
            .Where(s => s.Id == request.Id).FirstOrDefaultAsync();

        if (subject is null)
            return Result<Unit>.Fail($"{request.Id} not found");

        subject.Name = request.Name;
        subject.Code = request.Code;
        
        var newSubject = Context.Set<Subject>().Update(subject);
        await Context.SaveChangesAsync();

        if (newSubject is null)
            return Result<Unit>.Fail($"Не удалось обновить {request.Id}");

        return Result<Unit>.Success(Unit.Value);
    }
}
