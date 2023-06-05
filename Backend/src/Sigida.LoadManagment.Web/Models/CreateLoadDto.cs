using Sigida.LoadManagment.Application.Features.ViewModels;

namespace Sigida.LoadManagment.Web.Models;

public sealed record class CreateLoadDto
{
    public Guid SpecialtyId { get; init; }
    public Guid SubjectId { get; init; }
    public IEnumerable<SubjectScheduleDto> SubjectSchedule { get; set; }
}
