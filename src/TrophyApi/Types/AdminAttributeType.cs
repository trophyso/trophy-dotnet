using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<AdminAttributeType>))]
public enum AdminAttributeType
{
    [EnumMember(Value = "user")]
    User,

    [EnumMember(Value = "event")]
    Event,
}
