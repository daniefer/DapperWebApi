using System.Collections.Generic;
using System.Threading.Tasks;
using DapperBusiness.Features;
using DapperContracts.Houses;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypesController : ControllerBase
    {
        private readonly GetHouseEventTypes _getHouseEventTypes;

        public EventTypesController(GetHouseEventTypes getHouseEventTypes)
        {
            _getHouseEventTypes = getHouseEventTypes;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type>>> Get([FromQuery] List<int> ids)
        {
            return Ok(ids == null || ids.Count == 0 ? await _getHouseEventTypes.GetAll() : await _getHouseEventTypes.Get(ids));
        }
    }
}
