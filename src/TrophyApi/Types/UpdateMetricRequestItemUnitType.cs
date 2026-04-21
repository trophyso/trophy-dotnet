using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<UpdateMetricRequestItemUnitType>))]
public enum UpdateMetricRequestItemUnitType
{
    [EnumMember(Value = "number")]
    Number,

    [EnumMember(Value = "currency")]
    Currency,
}
