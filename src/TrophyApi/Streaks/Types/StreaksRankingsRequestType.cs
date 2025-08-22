using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<StreaksRankingsRequestType>))]
public enum StreaksRankingsRequestType
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "longest")]
    Longest,
}
