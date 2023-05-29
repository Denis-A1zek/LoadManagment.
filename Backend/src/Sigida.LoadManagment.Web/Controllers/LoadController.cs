using Microsoft.AspNetCore.Mvc;
using Sigida.LoadManagment.Application.Features;
using Sigida.LoadManagment.Web.Controllers.Base;
using Sigida.LoadManagment.Web.Models;

namespace Sigida.LoadManagment.Web.Controllers;

[ApiController]
[Route("api/plan")]
public class LoadController : BaseController
{
    
    [HttpGet("{id}/loads")]
    public async Task<IActionResult> GetAll(Guid id)
        => Ok(await Mediator.Send(new GetAllPlansQuery()));


    [HttpPost("{id}/load")]
    public async Task<IActionResult> Create(Guid id,CreateLoadDto request)
    {
        var value = HttpContext.Request.QueryString.Value;
        return Ok();
    }
}
