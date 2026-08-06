using Microsoft.AspNetCore.Mvc;
using backend_dotnet.Services;
using Microsoft.AspNetCore.Authorization;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/configurations")]
    [Authorize]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(
            IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet("{modelId}")]
        public async Task<IActionResult>
            GetConfiguration(int modelId)
        {
            var response =
                await _configurationService
                    .GetConfigurationAsync(modelId);

            return Ok(response);
        }

        [HttpGet("{modelId}/components/{componentId}/alternatives")]
        public async Task<IActionResult> GetAlternateComponents(int modelId, int componentId)
        {
            var response = await _configurationService
                    .GetAlternateComponentsAsync(
                        modelId,
                        componentId);

            return Ok(response);
        }
    }
}
