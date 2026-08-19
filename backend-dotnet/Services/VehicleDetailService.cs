using backend_dotnet.Data;
using backend_dotnet.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Services
{
    public class VehicleDetailService : IVehicleDetailService
    {
        private readonly ApplicationDbContext _context;

        public VehicleDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DefaultConfigurationDTO?> GetDefaultConfigurationAsync(int modelId)
        {
            var details = await _context.VehicleDetails
                .Include(v => v.Model)
                    .ThenInclude(m => m.Manufacturer)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Segment)
                .Include(v => v.Component)
                .Where(v => v.ModelId == modelId)
                .ToListAsync();

            if (!details.Any())
            {
                return null;
            }

            var first = details.First();

            var vehicle = new VehicleInfoDTO
            {
                ModelId = first.Model!.ModelId,
                ModelName = first.Model.ModelName,
                Image = first.Model.Image,
                BasePrice = first.Model.BasePrice,
                Manufacturer = first.Model.Manufacturer!.ManufacturerName,
                Segment = first.Model.Segment!.segmentName
            };

            var components = details.Select(detail => new ComponentInfoDTO
            {
                ConfigId = detail.ConfigId,
                ComponentName = detail.Component!.CompName,
                ComponentType = detail.CompType,
                Configurable = detail.IsConfigurable
            }).ToList();

            return new DefaultConfigurationDTO
            {
                Vehicle = vehicle,
                Components = components
            };
        }
    }
}
