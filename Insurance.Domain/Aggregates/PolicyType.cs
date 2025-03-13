namespace Insurance.Domain.Aggregates
{
    public sealed class PolicyType : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }

        private PolicyType() : base(Guid.NewGuid()) { }

        public PolicyType(string name, string description, decimal amount) : base(Guid.NewGuid())
        {
            Name = name;
            Description = description;
            Amount = amount;
        }
    }
}
