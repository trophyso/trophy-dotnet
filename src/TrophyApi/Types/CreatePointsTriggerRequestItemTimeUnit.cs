using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<CreatePointsTriggerRequestItemTimeUnit>))]
public enum CreatePointsTriggerRequestItemTimeUnit
{
    [EnumMember(Value = "hours")]
    Hours,

    [EnumMember(Value = "days")]
    Days,
}
