namespace Sigida.LoadManagment.Web.Models;

public sealed record class CreateLoadDto
{
    public bool IsCouting { get; init; }
    public Guid SpecialtyId { get; init; }
    public Guid SubjectId { get; init; }
    public Guid DepartmentId { get; init; }
}
