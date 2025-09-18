using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<LeaderboardResponseRankBy>))]
public enum LeaderboardResponseRankBy
{
    [EnumMember(Value = "points")]
    Points,

    [EnumMember(Value = "streak")]
    Streak,

    [EnumMember(Value = "metric")]
    Metric,
}
