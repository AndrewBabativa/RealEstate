namespace RealEstate.Core.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
