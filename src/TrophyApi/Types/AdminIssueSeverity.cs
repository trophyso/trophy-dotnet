using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<AdminIssueSeverity>))]
public enum AdminIssueSeverity
{
    [EnumMember(Value = "error")]
    Error,

    [EnumMember(Value = "warning")]
    Warning,
}
