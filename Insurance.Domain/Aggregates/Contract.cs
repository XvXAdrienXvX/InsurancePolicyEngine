namespace Insurance.Domain.Aggregates
{
    public class Contract : Entity, IAggregateRoot
    {
        public string ContractNumber { get; private set; }
        public string HolderName { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Status { get; private set; } // Active, Expired

        private List<Policy> _policies = new();
        public IReadOnlyCollection<Policy> Policies => _policies.AsReadOnly();

        private Contract() : base(Guid.NewGuid()) { }

        public Contract(string contractNumber, string holderName, DateTime startDate, DateTime endDate)
            : base(Guid.NewGuid())
        {
            ContractNumber = contractNumber;
            HolderName = holderName;
            StartDate = startDate;
            EndDate = endDate;
            Status = "Active";
        }

        public static Contract Create(string contractNumber, string holderName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(contractNumber))
            {
                throw new ArgumentException("Contract number cannot be empty.");
            }

            if (string.IsNullOrEmpty(holderName))
            {
                throw new ArgumentException("Holder name cannot be empty.");
            }

            if (startDate >= endDate)
            {
                throw new ArgumentException("End date must be greater than start date.");
            }

            return new Contract(contractNumber, holderName, startDate, endDate);
        }

        public void AddPolicy(Policy policy)
        {
            if (policy == null) throw new Exception("Policy cannot be null.");
            _policies.Add(policy);
        }
    }
}
