using Microsoft.AspNetCore.Mvc;
using Sigida.LoadManagment.Application.Features;

namespace Sigida.LoadManagment.Web.Controllers;

[ApiController]
[Route("api/")]
public class PlanController : BaseController
{
    [HttpGet("plans")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAll()
        => Ok(await Mediator.Send(new GetAllPlansQuery()));

    [HttpPost("plan")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> Create(CreatePlanCommand request)
    {
        var result = await Mediator.Send(request);
        return Created($"plan/{result.Reason}", result);
    }

    [HttpDelete("plan/{id}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Delte(Guid id)
        => Ok(await Mediator.Send(new DeletePlanCommand(id)));

    /// <summary>
    /// Gets the plan by id
    /// </summary>
    /// <remarks>
    /// GET: plan/8bd52a69-f36d-4a22-4868-08db6129bcd9
    /// </remarks>
    /// <param name="id">Id plan</param>
    /// <returns>PlanViewModel</returns>
    /// <response code="200">Success</response>
    [HttpGet("plan/{id}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetById(Guid id)
        => Ok(await Mediator.Send(new GetPlanByIdQuery(id)));
}
