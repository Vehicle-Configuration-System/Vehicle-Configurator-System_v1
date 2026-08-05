using backend_dotnet.Models;

namespace backend_dotnet.Repository
{
    public interface ISegmentRepository
    {

        Task<List<Segment>> GetAllSegmentsAsync();
        

        Task<Segment?> GetSegmentByIdAsync(int segmentId);

    }
}
