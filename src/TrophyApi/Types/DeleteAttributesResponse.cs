using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing deleted attributes represented by ID and any per-item issues, including invalid or missing attribute IDs.
/// </summary>
[Serializable]
public record DeleteAttributesResponse
{
    /// <summary>
    /// Array of deleted attributes represented by ID.
    /// </summary>
    [JsonPropertyName("deleted")]
    public IEnumerable<DeletedResource> Deleted { get; set; } = new List<DeletedResource>();

    /// <summary>
    /// Array of issues encountered during attribute deletion.
    /// </summary>
    [JsonPropertyName("issues")]
    public IEnumerable<AdminIssue> Issues { get; set; } = new List<AdminIssue>();

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
