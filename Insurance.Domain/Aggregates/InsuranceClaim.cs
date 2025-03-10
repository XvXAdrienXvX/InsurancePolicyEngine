namespace Insurance.Domain.Aggregates
{
    public sealed class InsuranceClaim : Entity, IAggregateRoot
    {
        public Guid PolicyId { get; private set; }
        public string ClaimNumber { get; private set; }
        public string Priority { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public string Status { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private set; }

        private InsuranceClaim() : base(Guid.NewGuid())
        {
        }

        public InsuranceClaim(Guid policyId, string claimNumber, string priority, string description, decimal amount): base(Guid.NewGuid())
        {
            PolicyId = policyId;
            ClaimNumber = claimNumber;
            Priority = priority;
            Description = description;
            Amount = amount;
            Status = "Active";
            DateCreated = DateTime.UtcNow;
            DateUpdated = DateTime.UtcNow;
        }

        public static InsuranceClaim Create(Guid policyId, string claimNumber, string priority, string description, decimal amount)
        {
            if (policyId == Guid.Empty) throw new ArgumentException("policy is required");
            if (claimNumber == "") throw new ArgumentException("claim number is required");

            return new InsuranceClaim
            {
                ClaimNumber = claimNumber,
                Priority = priority,
                Description = description,
                Amount = amount,
                Status = "Active",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
        }

        public void Update(string claimNumber, string description, decimal amount)
        {
            ClaimNumber = claimNumber;
            Description = description;
            Amount = amount;
            DateUpdated = DateTime.UtcNow;
        }

        public void Approve()
        {
            Status = "Approved";
            DateUpdated = DateTime.UtcNow;
        }

        public void Reject()
        {
            Status = "Rejected";
            DateUpdated = DateTime.UtcNow;
        }
    }
}
