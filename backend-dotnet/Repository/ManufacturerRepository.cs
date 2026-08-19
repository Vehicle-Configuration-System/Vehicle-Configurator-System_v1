using backend_dotnet.Data;
using Microsoft.EntityFrameworkCore;
using backend_dotnet.DTO;

namespace backend_dotnet.Repository
{
    public class ManufacturerRepository:IManufacturerRepository
    {
        private readonly ApplicationDbContext context;


        public ManufacturerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public List<ManufacturerDTO> GetManufacturersBySegment(int segmentId)
        {
            var manufacturers = context.SegMfgs
                .Where(sm => sm.SegmentId == segmentId)
                .Select(sm => new ManufacturerDTO
                {
                    ManufacturerId = sm.Manufacturer.ManufacturerId,
                    ManufacturerName = sm.Manufacturer.ManufacturerName
                })
                .ToList();


            return manufacturers;
        }
    }
}
