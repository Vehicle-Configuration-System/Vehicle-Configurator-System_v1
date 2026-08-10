
using backend_dotnet.Data;
using backend_dotnet.Models;

namespace backend_dotnet.Repositories
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly ApplicationDbContext _context;

        public ComponentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Component? GetById(int compId)
        {
            return _context.Components
                .FirstOrDefault(c => c.CompId == compId);
        }
    }
}
