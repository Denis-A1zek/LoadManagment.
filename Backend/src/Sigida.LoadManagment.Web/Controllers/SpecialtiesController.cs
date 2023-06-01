using Microsoft.AspNetCore.Mvc;
using Sigida.LoadManagment.Application.Features;
using Swashbuckle.AspNetCore.Annotations;

namespace Sigida.LoadManagment.Web.Controllers;

[ApiController]
[Route("api/")]
public class SpecialtiesController : BaseController
{
    /// <summary>
    /// Get all specialties
    /// </summary>
    /// <remarks>
    /// GET: api/specialty
    /// </remarks>
    /// <returns>List SpecialtyViewModel</returns>
    /// <response code="200">Success</response>
    [HttpGet("specialties")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAll()
        => Ok(await Mediator.Send(new GetAllSpecialtiesQuery()));

    /// <summary>
    /// Create specialty 
    /// </summary>
    /// <remarks>
    /// POST /specialty
    /// {
    ///     Code: "string",
    ///     Name: "string"
    /// }
    /// </remarks>
    /// <param name="request"></param>
    /// <returns>Id specialty</returns>
    /// <response code="200">Success</response>
    [HttpPost("specialty")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> Create(CreateSpecialtyCommand request)
    {
        var result = await Mediator.Send(request);
        return Created($"specialty/{result.Payload}", result);
    }
}
