using Microsoft.AspNetCore.Mvc;
using Sigida.LoadManagment.Application.Features;
using Sigida.LoadManagment.Web.Models;

namespace Sigida.LoadManagment.Web.Controllers;

[ApiController]
[Route("api/plan")]
public class PlanLoadController : BaseController
{
    
    [HttpGet("{id}/loads")]
    public async Task<IActionResult> GetAll(Guid id)
        => Ok(await Mediator.Send(new GetAllPlanLoadQuery(id)));

    /// <summary>
    /// Create the load on the plan
    /// </summary>
    /// <remarks>
    /// POST plan/8bd52a69-f36d-4a22-4868-08db6129bcd9/
    /// {
    ///     SubjectId: "Guid",
    ///     SpecialtyId: "Guid",
    ///     List SubjectScheduleDto: "{
    ///         int Course 
    ///         int Semester 
    ///         int LectureHours 
    ///         int LabHours 
    ///         int PracticeHours 
    ///         int SelfHours 
    ///     }"
    /// }
    /// </remarks>
    /// <param name="request"></param>
    /// <returns>Id employee</returns>
    /// <response code="200">Success</response>
    [HttpPost("{id}/load")]
    public async Task<IActionResult> Create(Guid id, CreateLoadDto request)
        => Ok(await Mediator.Send(
            new CreatePlanLoadCommand(
                id, request.SpecialtyId, request.SubjectId, request.SubjectSchedule)));
}
