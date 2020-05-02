using DapperContracts.CLR;
using System;
using System.Data;
using static Dapper.SqlMapper;

namespace DapperBusiness
{
    public class DateHandler : TypeHandler<Date>
    {
        public override Date Parse(object value)
        {
            if (value is Date date)
                return date;
            if (value is DateTime dateTime)
                return new Date(dateTime);
            throw new NotImplementedException();
        }

        public override void SetValue(IDbDataParameter parameter, Date value)
        {
            parameter.Value = ((IConvertible)value).ToDateTime(null);
            parameter.DbType = DbType.Date;
        }
    }
}
