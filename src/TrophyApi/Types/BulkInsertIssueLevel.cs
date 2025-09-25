using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<BulkInsertIssueLevel>))]
public enum BulkInsertIssueLevel
{
    [EnumMember(Value = "error")]
    Error,

    [EnumMember(Value = "warning")]
    Warning,
}
