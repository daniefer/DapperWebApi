using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperContracts.Houses;

namespace DapperBusiness.Features
{
    public class SaveHouseSources
    {
        private readonly IDbConnection _db;

        public SaveHouseSources(IDbConnection db)
        {
            _db = db;
        }

        public async Task<Source> Save(Source events)
        {
            var command = new CommandDefinition(@"
                DECLARE @Updates TABLE (Id INT)

                MERGE [House].[Sources] AS T
                    USING (SELECT 
                        @Id AS Id,
                        @Name AS Name,
                        @Joined AS Joined
                    ) AS S
                ON T.Id = S.Id
                WHEN MATCHED THEN
                    UPDATE SET
                        Name = S.Name,
                        Joined = S.Joined
                WHEN NOT MATCHED THEN
                    INSERT 
                        (Name, Joined)
                        VALUES
                        (S.Name, S.Joined)
                OUTPUT inserted.Id INTO @Updates
                ;

                SELECT *
                FROM [House].[Sources]
                WHERE Id IN (SELECT Id FROM @Updates)
                ;", events);
            return (await _db.QueryAsync<Source>(command)).First();
        }
    }
}
