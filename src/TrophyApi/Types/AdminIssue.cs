using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// An issue encountered while processing an item in an admin API request.
/// </summary>
[Serializable]
public record AdminIssue
{
    /// <summary>
    /// The ID of the user the issue relates to, when applicable.
    /// </summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    /// <summary>
    /// The ID of the points boost the issue relates to, when applicable.
    /// </summary>
    [JsonPropertyName("boostId")]
    public string? BoostId { get; set; }

    /// <summary>
    /// The zero-based index of the item the issue relates to, when no resource ID exists yet.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    /// <summary>
    /// The severity level of the issue.
    /// </summary>
    [JsonPropertyName("severity")]
    public required AdminIssueSeverity Severity { get; set; }

    /// <summary>
    /// A human-readable description of the issue.
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
