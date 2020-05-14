using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DapperContracts.Houses;

namespace DapperBusiness.Features
{
    public class GetHouseSources
    {
        private readonly IDbConnection _db;

        public GetHouseSources(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Source>> Get(ICollection<int> ids)
        {
            var command = new CommandDefinition(@"
                SELECT * 
                FROM [House].[Sources]
                WHERE Id in @ids", new { ids });
            return await _db.QueryAsync<Source>(command);
        }

        public async Task<IEnumerable<Source>> GetAll()
        {
            var command = new CommandDefinition(@"
                SELECT * 
                FROM [House].[Sources]");
            return await _db.QueryAsync<Source>(command);
        }
    }
}
