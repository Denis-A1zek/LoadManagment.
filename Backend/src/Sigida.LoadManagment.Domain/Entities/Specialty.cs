namespace Sigida.LoadManagment.Domain.Entities;

public class Specialty : Identity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
}
