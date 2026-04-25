using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<AdminLeaderboardRankBy>))]
public enum AdminLeaderboardRankBy
{
    [EnumMember(Value = "metric")]
    Metric,

    [EnumMember(Value = "streak")]
    Streak,

    [EnumMember(Value = "points")]
    Points,
}
