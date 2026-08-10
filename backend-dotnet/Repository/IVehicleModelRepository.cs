
using backend_dotnet.DTO;
using backend_dotnet.Models;

namespace backend_dotnet.Repositories
{
    public interface IVehicleModelRepository
    {
        VehicleModel? GetById(int modelId);

        List<VehicleModelDTO> GetModelsByManufacturerAndSegment(
            int manufacturerId,
            int segmentId);
    }
}
