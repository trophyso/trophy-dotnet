using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<PointsBoostWebhookPayloadStatus>))]
public enum PointsBoostWebhookPayloadStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "finished")]
    Finished,
}
