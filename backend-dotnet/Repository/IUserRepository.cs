using backend_dotnet.Models;

namespace backend_dotnet.Repository
{
    public interface IUserRepository
    {
        // Register User
        Task<User> RegisterUserAsync(User user);

        // Find User By Email
        Task<User?> GetUserByEmailAsync(string email);

        // Find User By Username
        Task<User?> GetUserByUsernameAsync(string username);

        // Check Email Exists
        Task<bool> EmailExistsAsync(string email);

        // Check Username Exists
        Task<bool> UsernameExistsAsync(string username);

        // Update User
        Task UpdateUserAsync(User user);

        // Delete User
        Task DeleteUserAsync(int userId);

        // Get User By Id
        Task<User?> GetUserByIdAsync(int userId);

        // Get All Users
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
