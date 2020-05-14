using System.Collections.Generic;
using System.Threading.Tasks;
using DapperBusiness.Features;
using DapperContracts.Houses;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly GetHouseEvents _getHouseEvents;
        private readonly SaveHouseEvents _saveHouseEvents;

        public EventsController(GetHouseEvents getHouseEvents, SaveHouseEvents saveHouseEvents)
        {
            _getHouseEvents = getHouseEvents;
            _saveHouseEvents = saveHouseEvents;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get([FromQuery] List<int> ids)
        {
            return Ok(ids == null || ids.Count == 0 ? await _getHouseEvents.GetAll() : await _getHouseEvents.Get(ids));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Event>> Post([FromBody] Event @event)
        {
            return Accepted(await _saveHouseEvents.Save(@event));
        }
    }
}
