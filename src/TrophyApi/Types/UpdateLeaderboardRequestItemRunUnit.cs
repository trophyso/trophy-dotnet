using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<UpdateLeaderboardRequestItemRunUnit>))]
public enum UpdateLeaderboardRequestItemRunUnit
{
    [EnumMember(Value = "day")]
    Day,

    [EnumMember(Value = "month")]
    Month,

    [EnumMember(Value = "year")]
    Year,
}
