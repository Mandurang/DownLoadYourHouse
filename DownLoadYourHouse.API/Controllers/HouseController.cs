using DownLoadYourHouse.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace DownLoadYourHouse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HouseController : ControllerBase
    {
        private static readonly Dictionary<Guid, House> house = new();

        private readonly ILogger<HouseController> _logger;

        public HouseController(ILogger<HouseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(house);
        }

        [HttpPost]
        public IActionResult Post(House house)
        {
            var id = Guid.NewGuid();
            HouseController.house.Add(id, house);
            return base.Ok(HouseController.house);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] House house)
        {
            var existingHouse = HouseController.house.GetValueOrDefault(id);
            if (existingHouse != null)
            {
                HouseController.house[id] = house;
            }
            return base.Ok(HouseController.house);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var existingHouse = house.GetValueOrDefault(id);
            return Ok(existingHouse);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            house.Remove(id);
            return Ok(house);
        }
    }
}