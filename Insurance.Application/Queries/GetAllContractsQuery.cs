using Insurance.Application.ResponseContracts;
using Insurance.Domain.Aggregates;
using Insurance.Domain.DataContracts;
using MediatR;

namespace Insurance.Application.Queries
{
    public record GetAllContractsQuery() : IRequest<APIResponse<IEnumerable<Contract>>>;

    public class GetAllContractsHandler : IRequestHandler<GetAllContractsQuery, APIResponse<IEnumerable<Contract>>>
    {
        private readonly IQueryRepository<Contract> _contractQueryRepo;

        public GetAllContractsHandler(IQueryRepository<Contract> contractQueryRepo)
        {
            _contractQueryRepo = contractQueryRepo;
        }

        public async Task<APIResponse<IEnumerable<Contract>>> Handle(GetAllContractsQuery handler, CancellationToken cancellationToken)
        {
            var contractList = await _contractQueryRepo.GetAllAsync();

            if (!contractList.Any())
                return APIResponse.Failure<IEnumerable<Contract>>("No contracts found");

            return APIResponse.Success(contractList);
        }
    }
}
