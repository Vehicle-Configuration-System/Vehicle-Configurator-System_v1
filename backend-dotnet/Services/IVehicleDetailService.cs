using backend_dotnet.DTO;

namespace backend_dotnet.Services
{
    public interface IVehicleDetailService
    {
        Task<DefaultConfigurationDTO?> GetDefaultConfigurationAsync(int modelId);
    }
}
