using System.ComponentModel.DataAnnotations;

namespace Sigida.LoadManagment.Domain.Entities;

public abstract class Identity 
{
    [Key]
    public Guid Id { get; set; }
}
