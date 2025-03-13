namespace Insurance.Application.RequestContracts
{
    public class CreatePolicyTypeRequest
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Amount { get; set; } = 0;
    }
}
