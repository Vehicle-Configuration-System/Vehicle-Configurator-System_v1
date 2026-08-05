using backend_dotnet.Data;
using backend_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Repository
{
    public class SegmentRepository : ISegmentRepository
    {
       private readonly ApplicationDbContext _context;

        public SegmentRepository(ApplicationDbContext _context) { 
            this._context = _context;
        }
        public async Task<List<Segment>> GetAllSegmentsAsync()
        {
             return await _context.Segments.ToListAsync();
        }

        public async Task<Segment?> GetSegmentByIdAsync(int id)
        {
            return await _context.Segments.FirstOrDefaultAsync(s=>s.segmentId==id);


        }
    }
}
