using backend_dotnet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/default-config")]
    [Authorize]
    public class VehicleDetailController : ControllerBase
    {
        private readonly IVehicleDetailService _vehicleDetailService;

        public VehicleDetailController(
            IVehicleDetailService vehicleDetailService)
        {
            _vehicleDetailService = vehicleDetailService;
        }

        [HttpGet("{modelId}")]
        public async Task<IActionResult> GetDefaultConfiguration(
            int modelId)
        {
            var response =
                await _vehicleDetailService
                    .GetDefaultConfigurationAsync(modelId);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
