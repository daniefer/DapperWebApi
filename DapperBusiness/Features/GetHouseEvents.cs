using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperContracts.Houses;

namespace DapperBusiness.Features
{
    public class GetHouseEvents
    {
        private readonly IDbConnection _db;

        public GetHouseEvents(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Event>> Get()
        {
            var command = new CommandDefinition(@"
                SELECT e.*, s.* 
                FROM [House].[Events] e
                INNER JOIN [House].[EventSources] s
                    ON e.EventSourceId = s.Id
                WHERE Id in @ids", new { ids = new[] { 1, 2, 3 } });
            return await _db.QueryAsync<Event>(command);
        }
    }
}
