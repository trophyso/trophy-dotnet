using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<LeaderboardResponseWithRankingsStatus>))]
public enum LeaderboardResponseWithRankingsStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "scheduled")]
    Scheduled,

    [EnumMember(Value = "finished")]
    Finished,
}
