using System.Collections.Generic;
using System.Data;
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

        public async Task<IEnumerable<Event>> Get(ICollection<int> ids)
        {
            var command = new CommandDefinition(@"
                SELECT e.*, s.* 
                FROM [House].[Events] e
                INNER JOIN [House].[Sources] s
                    ON e.SourceId = s.Id
                WHERE e.Id in @ids", new { ids });
            return await _db.QueryAsync<Event, Source, Event>(command, (e, s) => { e.Source = s; return e; });
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var command = new CommandDefinition(@"
                SELECT e.*, s.* 
                FROM [House].[Events] e
                INNER JOIN [House].[Sources] s
                    ON e.SourceId = s.Id");
            return await _db.QueryAsync<Event, Source, Event>(command, (e, s) => { e.Source = s; return e; });
        }
    }
}
