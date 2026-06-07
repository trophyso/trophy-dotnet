using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<StreakEvaluationModePreference>))]
public enum StreakEvaluationModePreference
{
    [EnumMember(Value = "OR")]
    Or,

    [EnumMember(Value = "AND")]
    And,
}
