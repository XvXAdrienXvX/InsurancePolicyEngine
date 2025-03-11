using Insurance.Application.Commands;
using Insurance.Application.Queries;
using Insurance.Application.RequestContracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("PolicyTypes")]
        public async Task<IActionResult> GetAllPolicyTypes()
        {
            var result = await _mediator.Send(new GetAllPolicyTypeQuery());
            return Ok(result);
        }
    }
}
