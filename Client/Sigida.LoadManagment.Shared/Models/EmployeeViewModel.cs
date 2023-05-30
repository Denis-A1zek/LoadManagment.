using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Shared.Models;

public sealed record EmployeeViewModel
{
    public Guid Id { get; init; }
    public string? FullName { get; init; }
    public string? PositionName { get; init; }
    public string? Load { get; init; }
}
