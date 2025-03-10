namespace Insurance.Application.RequestContracts
{
    public class CreateContractRequest
    {
        public string ContractNumber { get; set; }
        public string HolderName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Active";
    }
}
