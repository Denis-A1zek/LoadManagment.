using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Common.Models;

public sealed record PlanDetailsDto
{
    public Guid Id { get; init; }
    public string Description { get; init; }
    public int LoadCount { get; init; }
    public string Period { get; init; }
    
}
