using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<CreatedMetricUnitType>))]
public enum CreatedMetricUnitType
{
    [EnumMember(Value = "number")]
    Number,

    [EnumMember(Value = "currency")]
    Currency,
}
