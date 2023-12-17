using Swashbuckle.AspNetCore.Annotations;
using System.Runtime.Serialization;

namespace Settlement.Infrastructure.Models.StockModels
{
    public enum SettlementTimeSeries
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
