using backend_dotnet.DTO;
using backend_dotnet.Repository;

namespace backend_dotnet.Services
{
    public class ManufacturerService:IManufacturerService
    {

        private readonly IManufacturerRepository manufacturerRepository;


        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            this.manufacturerRepository = manufacturerRepository;
        }


        public List<ManufacturerDTO> GetManufacturersBySegment(int segmentId)
        {
            List<ManufacturerDTO> manufacturerList =
                manufacturerRepository.GetManufacturersBySegment(segmentId);


            return manufacturerList;
        }
    }
}
