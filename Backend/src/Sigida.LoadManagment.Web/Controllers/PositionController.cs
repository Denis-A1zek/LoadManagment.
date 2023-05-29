using Microsoft.AspNetCore.Mvc;
using Sigida.LoadManagment.Application.Features;
using Sigida.LoadManagment.Web.Controllers.Base;

namespace Sigida.LoadManagment.Web.Controllers;

[ApiController]
[Route("api/")]
public class PositionController : BaseController
{
    [HttpGet("positions")]
    [ProducesResponseType(200)]
    public async Task<ActionResult> GetAll()
        => Ok(await Mediator.Send(new GetPositionsQuery()));
}
