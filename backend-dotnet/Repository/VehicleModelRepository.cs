
using backend_dotnet.Data;
using backend_dotnet.DTO;
using backend_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public VehicleModel? GetById(int modelId)
        {
            return _context.VehicleModels
                .Include(v => v.Manufacturer)
                .Include(v => v.Segment)
                .FirstOrDefault(v => v.ModelId == modelId);
        }

        public List<VehicleModelDTO> GetModelsByManufacturerAndSegment(
            int manufacturerId,
            int segmentId)
        {
           
return _context.VehicleModels
    .Where(v =>
        v.ManufacturerId == manufacturerId &&
        v.SegmentId == segmentId)
    .Select(v => new VehicleModelDTO
    {
        ModelId = v.ModelId,
        ModelName = v.ModelName,
        MinimumQuantity = v.MinimumQuantity
    })
    .ToList();

        }
    }
}

