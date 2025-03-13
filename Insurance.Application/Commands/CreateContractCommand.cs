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
        private readonly IQueryRepository<PolicyType> _policyTypeRepo;

        public CreateContractHandler(ICommandRepository<Contract> contractCmdRepo, IQueryRepository<PolicyType> policyTypeRepo)
        {
            _contractCmdRepo = contractCmdRepo;
            _policyTypeRepo = policyTypeRepo;
        }

        public async Task<APIResponse<bool>> Handle(CreateContractCommand cmd, CancellationToken cancellationToken)
        {
            try
            {
                var newContract = Contract.Create(cmd.request.ContractNumber, cmd.request.HolderName, cmd.request.StartDate, cmd.request.EndDate);

                if (!cmd.request.PolicyIds.Any())
                    throw new Exception("No policies selected for the contract.");

                List<Guid> policyTypeIds = cmd.request.PolicyIds;
                var policyTypes = await _policyTypeRepo.FindAsync(p => policyTypeIds.Contains(p.Id));

                if (!policyTypes.Any())
                    throw new Exception("No policy types found.");

                var policies = policyTypes.Select(policyType => Policy.Create(newContract.Id, policyType, cmd.request.HolderName)).ToList();

                newContract.AddPolicies(policies);
                newContract.CalculateTotalPremium();

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
