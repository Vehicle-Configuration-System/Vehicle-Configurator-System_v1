using backend_dotnet.Models;
using backend_dotnet.Repository;

namespace backend_dotnet.Services
{
    public class SegmentService : ISegmentService
    {
        private readonly ISegmentRepository _segmentRepository;

        public SegmentService(ISegmentRepository segmentRepository)
        {
            _segmentRepository = segmentRepository;
        }

        public async Task<List<Segment>> GetAllSegmentsAsync()
        {
            return await _segmentRepository.GetAllSegmentsAsync();
        }

        public async Task<Segment?> GetSegmentByIdAsync(int segmentId)
        {
            return await _segmentRepository.GetSegmentByIdAsync(segmentId);
        }
    }
}