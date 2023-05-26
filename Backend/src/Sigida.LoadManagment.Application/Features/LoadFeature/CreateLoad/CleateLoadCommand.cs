using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features;

public sealed record CleateLoadCommand
{
    public bool IsCouting { get; init; }
    public Guid SpecialtyId { get; init; }
    public Guid SubjectId { get; init; }
    public Guid DepartmentId { get; init; }
}
