using Microsoft.AspNetCore.Mvc;
using Sigida.LoadManagment.Application.Features;
using Sigida.LoadManagment.Application.Features.DegreeFeature;
using Sigida.LoadManagment.Web.Controllers.Base;

namespace Sigida.LoadManagment.Web.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : BaseController
    {

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
            => Ok(await Mediator.Send(new GetAllEmployeeQuery()));

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete(Guid id)
            => Ok(await Mediator.Send(new DeleteEmployeeCommand(id)));

        [HttpGet]
        [Route("{page}/{pageSize}")]
        public async Task<IActionResult> GetPaged(int page, int pageSize)
            => Ok(await Mediator.Send(new GetAllEmployeeQuery()));

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetById(Guid id)
            => Ok(await Mediator.Send(new GetEmployeeByIdQuery(id)));

        //[HttpPut]
        //[Route("employee")]
        //public async Task<IActionResult> Update(UpdateEmployeeCommand request)


        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Create(CreateEmployeeCommand request)
        {
            var result = await Mediator.Send(request);
            return Created($"employee/{result.Payload}", result);
        }
            
    }
}
