using Insurance.Application.RequestContracts;
using Insurance.Application.ResponseContracts;
using Insurance.Domain.Aggregates;
using Insurance.Domain.DataContracts;
using MediatR;

namespace Insurance.Application.Commands
{
    public record CreateContractCommand(CreateContractRequest request) : IRequest<APIResponse<bool>>;

    public class CreateContractHandler : IRequestHandler<CreateContractCommand, APIResponse<bool>>
    {
        private readonly ICommandRepository<Contract> _contractCmdRepo;

        public CreateContractHandler(ICommandRepository<Contract> contractCmdRepo)
        {
            _contractCmdRepo = contractCmdRepo;
        }

        public async Task<APIResponse<bool>> Handle(CreateContractCommand cmd, CancellationToken cancellationToken)
        {
            try
            {
                var newContract = Contract.Create(cmd.request.ContractNumber, cmd.request.HolderName, cmd.request.StartDate, cmd.request.EndDate);

                var entity = await _contractCmdRepo.CreateAsync(newContract);

                return APIResponse.Success(true);
            }
            catch (Exception ex)
            {              
                return APIResponse.Failure<bool>($"An error occurred: {ex.Message}");
            }
        }
    }
}
