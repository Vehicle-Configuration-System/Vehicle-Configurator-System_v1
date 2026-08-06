using backend_dotnet.DTO;

namespace backend_dotnet.Services
{
    public interface IManufacturerService
    {
        List<ManufacturerDTO> GetManufacturersBySegment(int segmentId);
    }
}