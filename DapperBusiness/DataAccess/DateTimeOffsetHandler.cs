using System;
using System.Data;
using static Dapper.SqlMapper;

namespace DapperBusiness
{
    public class DateTimeOffsetHandler : TypeHandler<DateTimeOffset>
    {
        public override DateTimeOffset Parse(object value)
        {
            if (value is DateTimeOffset datetime)
                return datetime;
            throw new NotImplementedException();
        }

        public override void SetValue(IDbDataParameter parameter, DateTimeOffset value)
        {
            parameter.Value = value;
            parameter.DbType = DbType.DateTimeOffset;
        }
    }

    public class NullableDateTimeOffsetHandler : TypeHandler<DateTimeOffset?>
    {
        public override DateTimeOffset? Parse(object value)
        {
            if (value is null)
                return null;
            if (value is DateTimeOffset datetime)
                return datetime;
            throw new NotImplementedException();
        }

        public override void SetValue(IDbDataParameter parameter, DateTimeOffset? value)
        {
            parameter.Value = value.HasValue ? (object)value.Value : DBNull.Value;
            parameter.DbType = DbType.DateTimeOffset;
        }
    }
}
