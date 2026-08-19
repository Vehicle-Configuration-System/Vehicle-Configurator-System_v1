using backend_dotnet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService _vehicleModelService;

        public VehicleModelController(IVehicleModelService vehicleModelService)
        {
            _vehicleModelService = vehicleModelService;
        }

        [HttpGet("{manufacturerId}/{segmentId}")]
        public async Task<IActionResult> GetModelsByManufacturerAndSegment(int manufacturerId, int segmentId)
        {
            var models = await _vehicleModelService
                .GetModelsByManufacturerAndSegmentAsync(manufacturerId, segmentId);

            return Ok(models);
        }
    }
}
