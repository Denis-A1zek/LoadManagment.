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

public sealed record DeleteSubjectCommand(Guid Id) : IRequest<IResult<Guid>>;

public sealed class DeleteSubjectCommandHandler :
    BaseHandler, IRequestHandler<DeleteSubjectCommand, IResult<Guid>>
{
    public DeleteSubjectCommandHandler(ApplicationDbContext context) : base(context) { }

    public async Task<IResult<Guid>> Handle(DeleteSubjectCommand request, 
        CancellationToken cancellationToken)
    {
        var subjectInDb = await Context.Set<Subject>().FirstAsync(x => x.Id == request.Id);

        if (subjectInDb is null)
            return Result<Guid>.Fail($"{request.Id} not found");

        Context.Set<Subject>().Remove(subjectInDb);
        await Context.SaveChangesAsync();

        return Result<Guid>.Success(request.Id);
    }
}
