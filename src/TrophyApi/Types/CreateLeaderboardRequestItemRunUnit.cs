using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<CreateLeaderboardRequestItemRunUnit>))]
public enum CreateLeaderboardRequestItemRunUnit
{
    [EnumMember(Value = "day")]
    Day,

    [EnumMember(Value = "month")]
    Month,

    [EnumMember(Value = "year")]
    Year,
}
