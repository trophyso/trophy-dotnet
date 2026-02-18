using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<PointsBoostWebhookPayloadRounding>))]
public enum PointsBoostWebhookPayloadRounding
{
    [EnumMember(Value = "down")]
    Down,

    [EnumMember(Value = "up")]
    Up,

    [EnumMember(Value = "nearest")]
    Nearest,
}
