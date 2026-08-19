
using backend_dotnet.Data;
using backend_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Repositories
{
    public class VehicleDetailRepository : IVehicleDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<VehicleDetail> GetByModelId(int modelId)
        {
            return _context.VehicleDetails
        .Include(v => v.Component)
        .Where(v => v.ModelId == modelId)
        .ToList();
        }
    }
}
