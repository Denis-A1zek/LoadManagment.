using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Domain.Entities;

public class Position : Identity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public double MinLoad { get; set; }
    public double MaxLoad { get; set; }
}
