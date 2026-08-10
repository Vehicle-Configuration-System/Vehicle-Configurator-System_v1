
using backend_dotnet.Models;

namespace backend_dotnet.Repositories
{
    public interface IAlternateComponentRepository
    {
        List<AlternateComponent> GetByModelIdAndComponentId(
            int modelId,
            int componentId);

        AlternateComponent? FindByAlternateComponent_CompIdAndComponent_CompIdAndModel_ModelId(
            int altCompId,
            int compId,
            int modelId);
    }
}
