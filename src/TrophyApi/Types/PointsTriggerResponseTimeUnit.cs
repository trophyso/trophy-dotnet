using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<PointsTriggerResponseTimeUnit>))]
public enum PointsTriggerResponseTimeUnit
{
    [EnumMember(Value = "hour")]
    Hour,

    [EnumMember(Value = "day")]
    Day,
}
