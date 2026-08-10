
using backend_dotnet.Data;
using backend_dotnet.Models;

namespace backend_dotnet.Repositories
{
    public class AlternateComponentRepository : IAlternateComponentRepository
    {
        private readonly ApplicationDbContext _context;

        public AlternateComponentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AlternateComponent> GetByModelIdAndComponentId(
            int modelId,
            int componentId)
        {
            return _context.AlternateComponents
                .Where(a =>
                    a.ModelId == modelId &&
                    a.CompId == componentId)
                .ToList();
        }

        public AlternateComponent?
            FindByAlternateComponent_CompIdAndComponent_CompIdAndModel_ModelId(
                int altCompId,
                int compId,
                int modelId)
        {
            return _context.AlternateComponents
                .FirstOrDefault(a =>
                    a.AltCompId == altCompId &&
                    a.CompId == compId &&
                    a.ModelId == modelId);
        }
    }
}

