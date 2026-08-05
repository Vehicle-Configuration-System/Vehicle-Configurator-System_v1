using backend_dotnet.DTO;
using backend_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
   
        [Route("manufacturer")]
        [ApiController]
        public class ManufacturerController : ControllerBase
        {
            private readonly ManufacturerService manufacturerService;


            public ManufacturerController(ManufacturerService manufacturerService)
            {
                this.manufacturerService = manufacturerService;
            }


          



            // Get Manufacturers By Segment
            [HttpGet("segment/{segmentId}")]
            public ActionResult<List<ManufacturerDTO>> GetManufacturersBySegment(
                int segmentId)
            {
                List<ManufacturerDTO> manufacturerList =
                    manufacturerService.GetManufacturersBySegment(segmentId);


                return Ok(manufacturerList);
            }
        }
    
}
