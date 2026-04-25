using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<UpdateLeaderboardRequestItemStatus>))]
public enum UpdateLeaderboardRequestItemStatus
{
    [EnumMember(Value = "inactive")]
    Inactive,

    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "scheduled")]
    Scheduled,

    [EnumMember(Value = "finished")]
    Finished,
}
