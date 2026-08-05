using backend_dotnet.DTO;

namespace backend_dotnet.Services
{
    public interface IUserService
    {
        // Register New User
        Task<string> RegisterAsync(RegisterRequestDTO registerDto);

        // Login User
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginDto);

        // Get User By Id
        Task<UserResponseDTO?> GetUserByIdAsync(int userId);

        // Get All Users
        Task<IEnumerable<UserResponseDTO>> GetAllUsersAsync();

        // Delete User
        Task<bool> DeleteUserAsync(int userId);
    }
}
