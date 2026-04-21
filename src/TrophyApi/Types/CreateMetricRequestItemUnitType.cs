using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<CreateMetricRequestItemUnitType>))]
public enum CreateMetricRequestItemUnitType
{
    [EnumMember(Value = "number")]
    Number,

    [EnumMember(Value = "currency")]
    Currency,
}
