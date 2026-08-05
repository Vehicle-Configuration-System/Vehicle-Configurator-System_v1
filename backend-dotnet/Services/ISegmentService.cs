using backend_dotnet.Models;

namespace backend_dotnet.Services
{
    public interface ISegmentService
    {
        Task<List<Segment>> GetAllSegmentsAsync();

        Task<Segment?> GetSegmentByIdAsync(int segmentId);
    }
}