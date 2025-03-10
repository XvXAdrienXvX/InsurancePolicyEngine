using Insurance.Application.Commands;
using Insurance.Application.Queries;
using Insurance.Application.RequestContracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePolicyEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContractController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateContract")]
        public async Task<IActionResult> CreateContract([FromBody] CreateContractRequest request)
        {
            var result = await _mediator.Send(new CreateContractCommand(request));
            return Ok(result);
        }

        [HttpGet]
        [Route("Contracts")]
        public async Task<IActionResult> GetAllContracts()
        {
            var result = await _mediator.Send(new GetAllContractsQuery());
            return Ok(result);
        }
    }
}
