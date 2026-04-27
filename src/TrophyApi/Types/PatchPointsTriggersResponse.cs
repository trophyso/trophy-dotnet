using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing updated triggers and any issues encountered.
/// </summary>
[Serializable]
public record PatchPointsTriggersResponse
{
    /// <summary>
    /// Array of successfully updated triggers.
    /// </summary>
    [JsonPropertyName("updated")]
    public IEnumerable<AdminPointsTrigger> Updated { get; set; } = new List<AdminPointsTrigger>();

    /// <summary>
    /// Array of issues encountered during trigger updates.
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
