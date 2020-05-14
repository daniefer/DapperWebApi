using System.Collections.Generic;
using System.Threading.Tasks;
using DapperBusiness.Features;
using DapperContracts.Houses;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourcesController : ControllerBase
    {
        private readonly GetHouseSources _getHouseSources;
        private readonly SaveHouseSources _saveHouseSources;

        public SourcesController(GetHouseSources getHouseSources, SaveHouseSources saveHouseSources)
        {
            _getHouseSources = getHouseSources;
            _saveHouseSources = saveHouseSources;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Source>>> Get([FromQuery] List<int> ids)
        {
            return Ok(ids == null || ids.Count == 0 ? await _getHouseSources.GetAll() : await _getHouseSources.Get(ids));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Source>> Post([FromBody] Source source)
        {
            return Accepted(await _saveHouseSources.Save(source));
        }
    }
}
