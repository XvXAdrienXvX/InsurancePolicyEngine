namespace Insurance.Domain.Aggregates
{
    public sealed class Policy : Entity, IAggregateRoot
    {
        public Guid PolicyTypeId { get; private set; }
        public Guid ContractId { get; private set; }
        public string PolicyHolder { get; private set; }
        private List<InsuranceClaim> _claims = new();
        public IReadOnlyCollection<InsuranceClaim> Claims => _claims.AsReadOnly();
        public PolicyType PolicyType { get; private set; }
        private Policy(): base(Guid.NewGuid()) { }
        private Policy(Guid contractId, PolicyType policyType, string policyHolder)
        : base(Guid.NewGuid())
        {
            if (policyType == null) throw new ArgumentNullException(nameof(policyType), "Policy type is required.");

            ContractId = contractId;
            PolicyType = policyType;
            PolicyTypeId = policyType.Id;
            PolicyHolder = policyHolder;
        }

        public Policy(Guid contractId, Guid policyTypeId, string policyHolder): base(Guid.NewGuid())
        {
            ContractId = contractId;
            PolicyTypeId = policyTypeId;
            PolicyHolder = policyHolder;
        }

        public static Policy Create(Guid contractId, PolicyType policyType, string policyHolder)
        {
            if (contractId == Guid.Empty) throw new ArgumentException("Contract ID cannot be empty.", nameof(contractId));
            if (string.IsNullOrWhiteSpace(policyHolder)) throw new ArgumentException("Policy holder is required.", nameof(policyHolder));

            return new Policy(contractId, policyType, policyHolder);
        }

        public void AddPolicyType(PolicyType policyType)
        {
            if (policyType == null) throw new Exception("Policy type cannot be null.");
            PolicyType = policyType;
        }
    }
}
