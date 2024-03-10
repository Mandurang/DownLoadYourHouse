using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DownLoadYourHouse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeoapifyController : ControllerBase
    {
        private readonly GeoapifyService _geoapifyService;

        public GeoapifyController(GeoapifyService geoapifyService)
        {
            _geoapifyService = geoapifyService ?? throw new ArgumentNullException(nameof(geoapifyService));
        }

        [HttpGet]
        public async Task<IActionResult> GeocodeAddress(string address)
        {
            try
            {
                string response = await _geoapifyService.GeocodeAddressAsync(address);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
