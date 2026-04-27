using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<PatchPointsTriggersRequestItemTimeUnit>))]
public enum PatchPointsTriggersRequestItemTimeUnit
{
    [EnumMember(Value = "hours")]
    Hours,

    [EnumMember(Value = "days")]
    Days,
}
