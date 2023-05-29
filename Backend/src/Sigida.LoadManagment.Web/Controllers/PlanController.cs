using Microsoft.AspNetCore.Mvc;
using Sigida.LoadManagment.Application.Features;
using Sigida.LoadManagment.Web.Controllers.Base;

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
}
