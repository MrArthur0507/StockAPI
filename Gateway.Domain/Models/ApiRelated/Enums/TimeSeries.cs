using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Domain.Models.ApiRelated.Enums
{
    public enum TimeSeries
    {
        [EnumMember(Value = "INTRADAY")]
        INTRADAY,
        [EnumMember(Value = "DAILY")]
        DAILY,
        [EnumMember(Value = "DAILY_ADJUSTED")]
        DAILY_ADJUSTED,
        [EnumMember(Value = "WEEKLY")]
        WEEKLY,
        [EnumMember(Value = "WEEKLY_ADJUSTED")]
        WEEKLY_ADJUSTED,
        [EnumMember(Value = "MONTHLY")]
        MONTHLY,
        [EnumMember(Value = "MONTHLY_ADJUSTED")]
        MONTHLY_ADJUSTED
    }
}
