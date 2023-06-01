using Microsoft.AspNetCore.Mvc;
using Sigida.LoadManagment.Application.Features;
using Sigida.LoadManagment.Application.Features.DegreeFeature;

namespace Sigida.LoadManagment.Web.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EmployeeController : BaseController
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <remarks>
        /// GET: /employee
        /// </remarks>
        /// <returns>List EmployeeViewModel</returns>
        /// <response code="200">Success</response>
        [HttpGet("employees")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
            => Ok(await Mediator.Send(new GetAllEmployeeQuery()));


        /// <summary>
        /// Delete employee by id
        /// </summary>
        /// <remarks>
        /// DELETE: employee/8bd52a69-f36d-4a22-4868-08db6129bcd9
        /// </remarks>
        /// <param name="id">Guid:Id employee</param>
        /// <returns>Deleted user identity</returns>
        /// <response code="200">Success</response>
        [HttpDelete("employee/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete(Guid id)
            => Ok(await Mediator.Send(new DeleteEmployeeCommand(id)));


        /// <summary>
        /// Gets a list of employees with pagination
        /// </summary>
        /// <remarks>
        /// GET: employee/1/10
        /// </remarks>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>List EmployeeViewModel</returns>
        // <response code="200">Success</response>
        [HttpGet("{page}/{pageSize}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetPaged(int page, int pageSize)
            => Ok(await Mediator.Send(new GetEmployeesPaginationQuery(page, pageSize)));

        /// <summary>
        /// Gets the employee by id
        /// </summary>
        /// <remarks>
        /// GET: employee/8bd52a69-f36d-4a22-4868-08db6129bcd9
        /// </remarks>
        /// <param name="id">Id employee</param>
        /// <returns>EmployeeEditViewModel</returns>
        /// <response code="200">Success</response>
        [HttpGet("employee/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetById(Guid id)
            => Ok(await Mediator.Send(new GetEmployeeByIdQuery(id)));


        /// <summary>
        /// Updates employee data
        /// </summary>
        /// <remarks>
        /// PUT /employee
        /// {
        ///     Id: "Guid",
        ///     Name: "string",
        ///     Surname: "string",
        ///     LastName: "string",
        ///     Position Id: "Guid position"
        /// }
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Id employee</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("employee")]
        public async Task<IActionResult> Update(UpdateEmployeeCommand request)
            => Ok(await Mediator.Send(request));


        /// <summary>
        /// Create employee 
        /// </summary>
        /// <remarks>
        /// POST /employee
        /// {
        ///     Name: "string",
        ///     Surname: "string",
        ///     LastName: "string",
        ///     Position Id: "Guid position"
        /// }
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Id employee</returns>
        /// <response code="200">Success</response>
        [HttpPost("employee")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Create(CreateEmployeeCommand request)
        {
            var result = await Mediator.Send(request);
            return Created($"employee/{result.Payload}", result);
        }
            
    }
}
