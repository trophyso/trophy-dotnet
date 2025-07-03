using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<PointsTriggerResponseStatus>))]
public enum PointsTriggerResponseStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "archived")]
    Archived,
}
