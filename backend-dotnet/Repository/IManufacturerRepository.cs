using backend_dotnet.DTO;

namespace backend_dotnet.Repository
{
    public interface IManufacturerRepository
    {

        List<ManufacturerDTO> GetManufacturersBySegment(int segmentId);
    }
}
