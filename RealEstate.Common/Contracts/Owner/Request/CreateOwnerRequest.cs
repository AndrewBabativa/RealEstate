namespace RealEstate.Common.Contracts.Owner.Request
{
    public class CreateOwnerRequest
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public DateTime Birthday { get; set; }
    }
}
