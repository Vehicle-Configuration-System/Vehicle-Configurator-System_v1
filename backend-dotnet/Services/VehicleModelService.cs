using backend_dotnet.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend_dotnet.DTO;

namespace backend_dotnet.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly ApplicationDbContext _context;

        public VehicleModelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VehicleModelDTO>> GetModelsByManufacturerAndSegmentAsync(
            int manufacturerId,
            int segmentId)
        {
            return await _context.VehicleModels
                .Where(vm => vm.ManufacturerId == manufacturerId
                          && vm.SegmentId == segmentId)
                .Select(vm => new VehicleModelDTO
                {
                    ModelId = vm.ModelId,
                    ModelName = vm.ModelName,
                    MinimumQuantity = vm.MinimumQuantity
                })
                .ToListAsync();
        }
    }
}
