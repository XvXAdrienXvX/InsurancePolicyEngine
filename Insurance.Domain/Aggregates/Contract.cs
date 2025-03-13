namespace Insurance.Domain.Aggregates
{
    public class Contract : Entity, IAggregateRoot
    {
        public string ContractNumber { get; private set; }
        public string HolderName { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Status { get; private set; } // Active, Expired
        public decimal TotalPremium { get; private set; }
        private List<Policy> _policies = new();
        public IReadOnlyCollection<Policy> Policies => _policies.AsReadOnly();
        public List<Guid> PolicyIds { get; private set; } = new();

        private Contract() : base(Guid.NewGuid()) { }

        public Contract(string contractNumber, string holderName, DateTime startDate, DateTime endDate)
            : base(Guid.NewGuid())
        {
            ContractNumber = contractNumber;
            HolderName = holderName;
            StartDate = startDate;
            EndDate = endDate;
            Status = "Active";
            TotalPremium = 0;
        }

        public static Contract Create(string contractNumber, string holderName, DateTime startDate,DateTime endDate)
        {
            if (string.IsNullOrEmpty(contractNumber))
                throw new ArgumentException("Contract number cannot be empty.");

            if (string.IsNullOrEmpty(holderName))
                throw new ArgumentException("Holder name cannot be empty.");

            if (startDate >= endDate)
                throw new ArgumentException("End date must be greater than start date.");

            return new Contract(contractNumber, holderName, startDate, endDate);
        }

        public void AddPolicy(Policy policy)
        {
            if (policy == null) throw new Exception("Policy cannot be null.");

            _policies.Add(policy);
            PolicyIds.Add(policy.Id);
        }

        public void AddPolicies(List<Policy> policies)
        {
            if (policies == null || !policies.Any())
                throw new Exception("Policies cannot be null or empty.");

            _policies.AddRange(policies);
        }

        public void CalculateTotalPremium() => TotalPremium = _policies.Sum(p => p.PolicyType?.Amount ?? 0);

    }

}
