using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<CreateAttributeRequestItemType>))]
public enum CreateAttributeRequestItemType
{
    [EnumMember(Value = "user")]
    User,

    [EnumMember(Value = "event")]
    Event,
}
