namespace Sigida.LoadManagment.Domain.Entities;

public class Plan : Identity
{
    public string Description { get; set; } = null!;
    public List<Load>? Loads { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}
