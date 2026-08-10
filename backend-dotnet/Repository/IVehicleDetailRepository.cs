
using backend_dotnet.Models;

namespace backend_dotnet.Repositories
{
    public interface IVehicleDetailRepository
    {
        List<VehicleDetail> GetByModelId(int modelId);
    }
}
