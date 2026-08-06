using backend_dotnet.DTO;
using backend_dotnet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("manufacturer")]
        public class ManufacturerController : ControllerBase
        {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }




        // Get Manufacturers By Segment
        [HttpGet("segment/{segmentId}")]
            public ActionResult<List<ManufacturerDTO>> GetManufacturersBySegment(
                int segmentId)
            {
                List<ManufacturerDTO> manufacturerList =
                    _manufacturerService.GetManufacturersBySegment(segmentId);


                return Ok(manufacturerList);
            }
        }
    
}
