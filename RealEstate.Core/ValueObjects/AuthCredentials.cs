namespace RealEstate.Core.ValueObjects
{
    public class AuthCredentials
    {
        public string Username { get; }
        public string Password { get; }

        public AuthCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
