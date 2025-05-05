namespace RealEstate.Common.Contracts.Owner.Responses
{
    public class OwnerResponse
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
