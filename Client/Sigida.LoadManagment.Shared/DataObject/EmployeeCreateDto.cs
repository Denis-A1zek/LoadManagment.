using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Shared.DataObject;

public sealed record EmployeeCreateDto
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Surname { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public Guid PositionId { get; set; }
}
