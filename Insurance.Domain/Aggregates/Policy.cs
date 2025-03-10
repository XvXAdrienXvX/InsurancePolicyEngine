namespace Insurance.Domain.Aggregates
{
    public sealed class Policy : Entity, IAggregateRoot
    {
        public Guid PolicyTypeId { get; private set; }
        public Guid ContractId { get; private set; }
        public string PolicyHolder { get; private set; }
        public decimal PremiumAmount { get; private set; }
        private List<InsuranceClaim> _claims = new();
        public IReadOnlyCollection<InsuranceClaim> Claims => _claims.AsReadOnly();

        private Policy(): base(Guid.NewGuid()) { }

        public Policy(Guid contractId, Guid policyTypeId, string policyHolder, decimal premiumAmount): base(Guid.NewGuid())
        {
            ContractId = contractId;
            PolicyTypeId = policyTypeId;
            PolicyHolder = policyHolder;
            PremiumAmount = premiumAmount;
        }

        public void SubmitClaim(string claimNumber, string priority, string description, decimal amount)
        {
            if (amount <= 0) throw new Exception("Claim amount must be positive.");
            _claims.Add(new InsuranceClaim(this.Id, claimNumber, priority, description, amount));
        }
    }
}
