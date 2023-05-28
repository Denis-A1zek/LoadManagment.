namespace Sigida.LoadManagment.Domain.Entities;

public class Subject : Identity
{
    public string Code { get; set; }
    public string Name { get; set; } = null!;
}
