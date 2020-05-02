using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperBusiness.Features;
using DapperContracts.Houses;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly GetHouseEvents _getHouseEvents;
        private readonly SaveHouseEvents _saveHouseEvents;

        public ValuesController(GetHouseEvents getHouseEvents, SaveHouseEvents saveHouseEvents)
        {
            _getHouseEvents = getHouseEvents;
            _saveHouseEvents = saveHouseEvents;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            return Ok(await _getHouseEvents.Get());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Event>> Post([FromBody] Event @event)
        {
            return Accepted(await _saveHouseEvents.Save(@event));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
