using backend_dotnet.Models;
using backend_dotnet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("segment")]

    public class SegmentController:ControllerBase
    {
        private readonly ISegmentService _segmentService;

        public SegmentController(ISegmentService segmentService) { 
            _segmentService = segmentService;
        }

        [HttpGet]
       public async Task<ActionResult<List<Segment>>> GetAllSegments() { 
            var segments = await _segmentService.GetAllSegmentsAsync();

            return Ok(segments);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Segment>> GetSegmentById(int id)
        {
            var segment = await _segmentService.GetSegmentByIdAsync(id);

            if (segment == null)
            {
                return NotFound();
            }

            return Ok(segment);
        }
    }
}
