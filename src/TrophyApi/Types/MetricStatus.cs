using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<MetricStatus>))]
public enum MetricStatus
{
    [EnumMember(Value = "archived")]
    Archived,

    [EnumMember(Value = "active")]
    Active,
}
