using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<AdminPointsBoostRounding>))]
public enum AdminPointsBoostRounding
{
    [EnumMember(Value = "down")]
    Down,

    [EnumMember(Value = "up")]
    Up,

    [EnumMember(Value = "nearest")]
    Nearest,
}
