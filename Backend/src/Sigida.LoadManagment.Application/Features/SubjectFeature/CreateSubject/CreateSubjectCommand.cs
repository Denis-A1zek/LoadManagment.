using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Common.Models;
using Sigida.LoadManagment.Application.Features.Base;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;

namespace Sigida.LoadManagment.Application.Features;

public sealed record CreateSubjectCommand(string Code, string Name) : IRequest<IResult<Guid>>;

public sealed class CreateSubjectCommandHandler : BaseHandler, IRequestHandler<CreateSubjectCommand, IResult<Guid>>
{
    public CreateSubjectCommandHandler(ApplicationDbContext context) : base(context) { }

    public async Task<IResult<Guid>> Handle
        (CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subjectInDb = await Context.Set<Subject>()
                .FirstOrDefaultAsync(s => s.Code.Equals(request.Code));

        if (subjectInDb is not null)
            return Result<Guid>.Fail($"{subjectInDb.Id} contains in db");

        var subject = new Subject()
        {
            Code = request.Code,
            Name = request.Name
        };

        await Context.Set<Subject>().AddAsync(subject);
        await Context.SaveChangesAsync();

        return Result<Guid>.Success(subject.Id);
    }
}
