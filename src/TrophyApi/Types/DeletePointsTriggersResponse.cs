using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing the points triggers that were deleted and any per-item issues.
/// </summary>
[Serializable]
public record DeletePointsTriggersResponse
{
    /// <summary>
    /// Array of deleted points triggers represented by ID.
    /// </summary>
    [JsonPropertyName("deleted")]
    public IEnumerable<DeletedResource> Deleted { get; set; } = new List<DeletedResource>();

    /// <summary>
    /// Array of issues encountered during trigger deletion.
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
