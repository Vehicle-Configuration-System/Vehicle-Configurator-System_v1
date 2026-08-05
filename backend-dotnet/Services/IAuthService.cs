

    using backend_dotnet.DTO;
    using global::backend_dotnet.DTO;

    namespace backend_dotnet.Services
    {
        public interface IAuthService
        {
            Task Register(RegisterRequestDto request);

            Task<LoginResponseDto> Login(LoginRequestDto request);
        }
    }
