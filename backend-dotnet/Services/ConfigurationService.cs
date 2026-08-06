using backend_dotnet.Data;
using backend_dotnet.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly ApplicationDbContext _context;

        public ConfigurationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConfigurationResponseDTO>> GetConfigurationAsync(int modelId)
        {
            var vehicleDetails = await _context.VehicleDetails
                .Include(v => v.Component)
                .Where(v => v.ModelId == modelId)
                .ToListAsync();

            return vehicleDetails.Select(detail =>
                new ConfigurationResponseDTO
                {
                    ComponentId = detail.Component!.CompId,
                    ComponentName = detail.Component.CompName,
                    ComponentType = detail.CompType,
                    Configurable = detail.IsConfigurable
                }
                ).ToList();
        }

        public async Task<List<AlternateComponentDTO>> GetAlternateComponentsAsync(int modelId, int componentId)
        {
            var list = await _context.AlternateComponents
                .Include(a => a.AlternateComponentEntity)
                .Where(a => a.ModelId == modelId && a.CompId == componentId)
                .ToListAsync();

            return list.Select(alt => 
                new AlternateComponentDTO
                {
                    AltId = alt.AltId,
                    ComponentId = alt.AlternateComponentEntity!.CompId,
                    ComponentName = alt.AlternateComponentEntity.CompName,
                    DeltaPrice = alt.DeltaPrice
                }
                ).ToList();
        }
    }
}
