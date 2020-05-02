using System;
using System.Data;
using static Dapper.SqlMapper;

namespace DapperBusiness
{
    public class TimeZoneInfoHandler : TypeHandler<TimeZoneInfo>
    {
        private readonly int identifierSize;

        public TimeZoneInfoHandler(int timezoneIdentifierMaxLength)
        {
            identifierSize = timezoneIdentifierMaxLength;
        }

        public override TimeZoneInfo Parse(object value)
        {
            if (value is string identifier)
                return TimeZoneInfo.FindSystemTimeZoneById(identifier);
            throw new NotImplementedException();
        }

        public override void SetValue(IDbDataParameter parameter, TimeZoneInfo value)
        {
            parameter.Value = value.Id;
            parameter.DbType = DbType.String;
            parameter.Size = identifierSize;
        }
    }
}
