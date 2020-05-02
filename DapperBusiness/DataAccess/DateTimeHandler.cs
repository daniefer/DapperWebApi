using System;
using System.Data;
using static Dapper.SqlMapper;

namespace DapperBusiness
{
    public class DateTimeHandler : TypeHandler<DateTime>
    {
        public override DateTime Parse(object value)
        {
            if (value is DateTime datetime)
                return DateTime.SpecifyKind(datetime, DateTimeKind.Utc);
            throw new NotImplementedException();
        }

        public override void SetValue(IDbDataParameter parameter, DateTime value)
        {
            parameter.Value = DateTime.SpecifyKind(value, DateTimeKind.Utc);
            parameter.DbType = DbType.DateTime2;
        }
    }

    public class NullableDateTimeHandler : TypeHandler<DateTime?>
    {
        public override DateTime? Parse(object value)
        {
            if (value is DateTime datetime)
                return DateTime.SpecifyKind(datetime, DateTimeKind.Utc);
            throw new NotImplementedException();
        }

        public override void SetValue(IDbDataParameter parameter, DateTime? value)
        {
            parameter.Value = DateTime.SpecifyKind(value.Value, DateTimeKind.Utc);
            parameter.DbType = DbType.DateTime2;
        }
    }
}
