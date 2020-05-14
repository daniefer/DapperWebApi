using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DapperContracts.Houses;

namespace DapperBusiness.Features
{
    public class GetHouseEventTypes
    {
        private readonly IDbConnection _db;

        public GetHouseEventTypes(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Type>> Get(ICollection<int> ids)
        {
            var command = new CommandDefinition(@"
                SELECT * 
                FROM [House].[Types]
                WHERE Id in @ids", new { ids });
            return await _db.QueryAsync<Type>(command);
        }

        public async Task<IEnumerable<Type>> GetAll()
        {
            var command = new CommandDefinition(@"
                SELECT * 
                FROM [House].[Types]");
            return await _db.QueryAsync<Type>(command);
        }
    }
}
