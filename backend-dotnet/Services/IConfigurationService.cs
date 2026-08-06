using backend_dotnet.DTO;

namespace backend_dotnet.Services
{
    public interface IConfigurationService
    {
        Task<List<ConfigurationResponseDTO>> GetConfigurationAsync(int modelId);

        Task<List<AlternateComponentDTO>> GetAlternateComponentsAsync(int modelId, int componentId);
    }
}
