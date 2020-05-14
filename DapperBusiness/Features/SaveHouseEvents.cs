using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperContracts.Houses;

namespace DapperBusiness.Features
{
    public class SaveHouseEvents
    {
        private readonly IDbConnection _db;

        public SaveHouseEvents(IDbConnection db)
        {
            _db = db;
        }

        public async Task<Event> Save(Event events)
        {
            var command = new CommandDefinition(@"
                DECLARE @Updates TABLE (Id INT)

                MERGE [House].[Events] AS T
                    USING (SELECT 
                        @Id AS Id,
                        @Type AS Type,
                        @EnteredDate AS EnteredDate,
                        @UtcTimestamp AS UtcTimestamp,
                        @Timestamp AS Timestamp,
                        @TimeZone AS TimeZone,
                        @SourceId as SourceId
                    ) AS S
                ON T.Id = S.Id
                WHEN MATCHED THEN
                    UPDATE SET
                        Type = S.Type,
                        EnteredDate = S.EnteredDate,
                        UtcTimestamp = S.UtcTimestamp,
                        Timestamp = S.Timestamp,
                        TimeZone = S.TimeZone,
                        SourceId = S.SourceId
                WHEN NOT MATCHED THEN
                    INSERT 
                        (Type, EnteredDate, UtcTimestamp, Timestamp, TimeZone, SourceId)
                        VALUES
                        (S.Type, S.EnteredDate, S.UtcTimestamp, S.Timestamp, S.TimeZone, S.SourceId)
                OUTPUT inserted.Id INTO @Updates
                ;

                SELECT E.*, S.*
                FROM [House].[Events] E
                INNER JOIN [House].[Sources] S
                ON S.Id = E.SourceId
                WHERE E.Id IN (SELECT Id FROM @Updates)
                ;", events);
            return (await _db.QueryAsync<Event, Source, Event>(command, (e, s) => { e.Source = s; return e; })).First();
        }
    }
}
