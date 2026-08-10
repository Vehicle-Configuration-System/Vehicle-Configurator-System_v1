
using backend_dotnet.Models;

namespace backend_dotnet.Repositories
{
    public interface IComponentRepository
    {
        Component? GetById(int compId);
    }
}
