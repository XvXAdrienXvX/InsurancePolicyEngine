using Insurance.Application.RequestContracts;
using Insurance.Application.ResponseContracts;
using Insurance.Domain.Aggregates;
using Insurance.Domain.DataContracts;
using MediatR;

namespace Insurance.Application.Commands
{
    public record CreatePolicyTypeCommand(CreatePolicyTypeRequest request) : IRequest<APIResponse<bool>>;

    public class CreatePolicyTypeHandler : IRequestHandler<CreatePolicyTypeCommand, APIResponse<bool>>
    {
        private readonly ICommandRepository<PolicyType> _policyTypeCmdRepo;

        public CreatePolicyTypeHandler(ICommandRepository<PolicyType> policyTypeCmdRepo)
        {
            _policyTypeCmdRepo = policyTypeCmdRepo;
        }

        public async Task<APIResponse<bool>> Handle(CreatePolicyTypeCommand cmd, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _policyTypeCmdRepo.CreateAsync(new PolicyType(cmd.request.Name, cmd.request.Description));

                return APIResponse.Success(true);
            }
            catch (Exception ex)
            {
                return APIResponse.Failure<bool>($"An error occurred: {ex.Message}");
            }
        }
    }
}
