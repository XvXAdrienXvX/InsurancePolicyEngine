using Insurance.Application.Commands;
using Insurance.Application.RequestContracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsurancePolicyEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PolicyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreatePolicyType")]
        public async Task<IActionResult> CreatePolicyType([FromBody] CreatePolicyTypeRequest request)
        {
            var result = await _mediator.Send(new CreatePolicyTypeCommand(request));
            return Ok(result);
        }
    }
}
