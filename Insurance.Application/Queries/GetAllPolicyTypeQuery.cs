using Insurance.Application.ResponseContracts;
using Insurance.Domain.Aggregates;
using Insurance.Domain.DataContracts;
using MediatR;

namespace Insurance.Application.Queries
{
    public record GetAllPolicyTypeQuery() : IRequest<APIResponse<IEnumerable<PolicyType>>>;

    public class GetAllPolicyTypeHandler : IRequestHandler<GetAllPolicyTypeQuery, APIResponse<IEnumerable<PolicyType>>>
    {
        private readonly IQueryRepository<PolicyType> _policyTypeQueryRepo;

        public GetAllPolicyTypeHandler(IQueryRepository<PolicyType> policyTypeQueryRepo)
        {
            _policyTypeQueryRepo = policyTypeQueryRepo;
        }

        public async Task<APIResponse<IEnumerable<PolicyType>>> Handle(GetAllPolicyTypeQuery handler, CancellationToken cancellationToken)
        {
            var contractList = await _policyTypeQueryRepo.GetAllAsync();

            if (!contractList.Any())
                return APIResponse.Failure<IEnumerable<PolicyType>>("No policy types found");

            return APIResponse.Success(contractList);
        }
    }
}
