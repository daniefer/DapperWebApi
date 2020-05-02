using DapperContracts.CLR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DapperContracts.Houses
{
    public class Event
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public Date EnteredDate { get; set; }

        public DateTime UtcTimestamp { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public TimeZoneInfo TimeZone { get; set; }

        public int SourceId { get; set; }

        public Source Source { get; set; }
    }
}
