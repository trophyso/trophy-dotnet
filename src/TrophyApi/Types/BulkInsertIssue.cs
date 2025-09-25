using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record BulkInsertIssue
{
    /// <summary>
    /// The ID of the user the issue relates to.
    /// </summary>
    [JsonPropertyName("userId")]
    public required string UserId { get; set; }

    /// <summary>
    /// The severity level of the issue.
    /// </summary>
    [JsonPropertyName("level")]
    public required BulkInsertIssueLevel Level { get; set; }

    /// <summary>
    /// A human-readable description of the issue.
    /// </summary>
    [JsonPropertyName("reason")]
    public required string Reason { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
