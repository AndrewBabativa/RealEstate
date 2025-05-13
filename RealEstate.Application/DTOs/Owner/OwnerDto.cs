namespace RealEstate.Application.DTOs.Owner
{
    public class OwnerDto
    {
        public int OwnerId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhotoUrl { get; set; } = null!;
        public DateTime Birthday { get; set; }
    }
}
