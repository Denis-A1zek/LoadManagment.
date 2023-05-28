using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Domain.Entities;

public class Employee : Identity
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public Guid PositionId { get; set; }
    public Position? Position { get; set; }
    public Guid DegreeId { get; set; }
    public Degree? Degree { get; set; }
}
