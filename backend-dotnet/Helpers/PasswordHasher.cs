namespace backend_dotnet.Helpers
{
    public class PasswordHasher
    {

        // Registration time
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }



        // Login time
        public bool VerifyPassword(
            string password,
            string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(
                password,
                passwordHash);
        }

    }
}