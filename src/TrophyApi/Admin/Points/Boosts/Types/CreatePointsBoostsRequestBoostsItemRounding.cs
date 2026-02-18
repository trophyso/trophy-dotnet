using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin.Points;

[JsonConverter(typeof(EnumSerializer<CreatePointsBoostsRequestBoostsItemRounding>))]
public enum CreatePointsBoostsRequestBoostsItemRounding
{
    [EnumMember(Value = "down")]
    Down,

    [EnumMember(Value = "up")]
    Up,

    [EnumMember(Value = "nearest")]
    Nearest,
}
