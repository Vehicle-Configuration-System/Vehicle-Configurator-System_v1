

    using backend_dotnet.DTOs;
    using global::backend_dotnet.DTOs;

    namespace backend_dotnet.Services
    {
        public interface IAuthService
        {
            Task Register(RegisterRequestDto request);

            Task<LoginResponseDto> Login(LoginRequestDto request);
        }
    }