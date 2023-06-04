using Microsoft.AspNetCore.Mvc;
using Sigida.LoadManagment.Application.Features;

namespace Sigida.LoadManagment.Web.Controllers;

[ApiController]
[Route("api")]
public class SubjectsController : BaseController
{
    /// <summary>
    /// Get all subjects
    /// </summary>
    /// <remarks>
    /// GET: api/subjects
    /// </remarks>
    /// <returns>List Subjects</returns>
    /// <response code="200">Success</response>
    [HttpGet("subjects")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAll()
        => Ok(await Mediator.Send(new GetAllSubjectsQuery()));

    /// <summary>
    /// Create subject 
    /// </summary>
    /// <remarks>
    /// POST api/subject
    /// {
    ///     Code: "string",
    ///     Name: "string"
    /// }
    /// </remarks>
    /// <param name="request"></param>
    /// <returns>Id subject</returns>
    /// <response code="200">Success</response>
    [HttpPost("subject")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> Create(CreateSubjectCommand request)
    {
        var result = await Mediator.Send(request);
        return Created($"subject/{result.Payload}", result);
    }

    /// <summary>
    /// Delete subject by id
    /// </summary>
    /// <remarks>
    /// DELETE: subject/8bd52a69-f36d-4a22-4868-08db6129bcd9
    /// </remarks>
    /// <param name="id">Guid:Id subject</param>
    /// <returns>Deleted subject identity</returns>
    /// <response code="200">Success</response>
    [HttpDelete("subject/{id}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Delete(Guid id)
        => Ok(await Mediator.Send(new DeleteSubjectCommand(id)));

    /// <summary>
    /// Gets the subject by id
    /// </summary>
    /// <remarks>
    /// GET: subject/8bd52a69-f36d-4a22-4868-08db6129bcd9
    /// </remarks>
    /// <param name="id">Id subject</param>
    /// <returns>SubjectViewModel</returns>
    /// <response code="200">Success</response>
    [HttpGet("subject/{id}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetById(Guid id)
        => Ok(await Mediator.Send(new GetSubjectByIdQuery(id)));

    /// <summary>
    /// Updates subject data
    /// </summary>
    /// <remarks>
    /// PUT /subject
    /// {
    ///     Id: "Guid",
    ///     Name: "string",
    ///     Code: "string",
    /// }
    /// </remarks>
    /// <param name="request"></param>
    /// <returns>Unit</returns>
    /// <response code="200">Success</response>
    [HttpPut]
    [Route("subject")]
    public async Task<IActionResult> Update(UpdateSubjectCommand request)
        => Ok(await Mediator.Send(request));
}
