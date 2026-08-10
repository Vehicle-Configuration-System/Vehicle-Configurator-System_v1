
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
            return await _context.VehicleDetails
                .Where(v => v.ModelId == modelId)
                .Select(v => new ConfigurationResponseDTO
                {
                    ComponentId = v.CompId,
                    ComponentName = v.Component.CompName,
                    ComponentType = v.CompType,
                    Configurable = v.IsConfigurable
                })
                .ToListAsync();
        }

        public async Task<List<AlternateComponentDTO>> GetAlternateComponentsAsync(
            int modelId,
            int componentId)
        {
            return await _context.AlternateComponents
                .Where(a =>
                    a.ModelId == modelId &&
                    a.CompId == componentId)
                .Select(a => new AlternateComponentDTO
                {
                    AltId = a.AltId,
                    ComponentId = a.AlternateComponentEntity.CompId,
                    ComponentName = a.AlternateComponentEntity.CompName,
                    DeltaPrice = a.DeltaPrice
                })
                .ToListAsync();
        }
    }
}
