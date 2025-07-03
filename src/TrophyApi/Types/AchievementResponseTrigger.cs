using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<AchievementResponseTrigger>))]
public enum AchievementResponseTrigger
{
    [EnumMember(Value = "metric")]
    Metric,

    [EnumMember(Value = "streak")]
    Streak,

    [EnumMember(Value = "api")]
    Api,
}
