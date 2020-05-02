using System;
using System.Collections.Generic;
using System.Text;

namespace DapperBusiness
{
    public static class DapperUtilities
    {
        public static void RegisterDapperHandlers()
        {
            Dapper.SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
            Dapper.SqlMapper.AddTypeHandler(new DateTimeHandler());
            Dapper.SqlMapper.AddTypeHandler(new DateHandler());
            Dapper.SqlMapper.AddTypeHandler(new TimeZoneInfoHandler(50));
        }
    }
}
