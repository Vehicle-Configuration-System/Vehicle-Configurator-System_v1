using backend_dotnet.Models;
using backend_dotnet.DTO;

namespace backend_dotnet.Services
{
    public interface IVehicleModelService
    {
        Task<List<VehicleModelDTO>> GetModelsByManufacturerAndSegmentAsync(int manufacturerId, int segmentId);
    }
}
