using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing restored users and any issues encountered.
/// </summary>
[Serializable]
public record RestoreStreaksResponse
{
    /// <summary>
    /// Array of user IDs whose streaks were successfully restored.
    /// </summary>
    [JsonPropertyName("restoredUsers")]
    public IEnumerable<string> RestoredUsers { get; set; } = new List<string>();

    /// <summary>
    /// Array of issues encountered during streak restoration.
    /// </summary>
    [JsonPropertyName("issues")]
    public IEnumerable<BulkInsertIssue> Issues { get; set; } = new List<BulkInsertIssue>();

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
