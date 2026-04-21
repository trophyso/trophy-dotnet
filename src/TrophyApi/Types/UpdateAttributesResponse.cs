using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing updated attributes and any per-item issues identified by attribute ID.
/// </summary>
[Serializable]
public record UpdateAttributesResponse
{
    /// <summary>
    /// Array of successfully updated attributes.
    /// </summary>
    [JsonPropertyName("updated")]
    public IEnumerable<AdminAttribute> Updated { get; set; } = new List<AdminAttribute>();

    /// <summary>
    /// Array of issues encountered during attribute update.
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
