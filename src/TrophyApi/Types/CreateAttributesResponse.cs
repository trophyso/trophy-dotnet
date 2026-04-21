using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing created attributes and any per-item issues.
/// </summary>
[Serializable]
public record CreateAttributesResponse
{
    /// <summary>
    /// Array of successfully created attributes.
    /// </summary>
    [JsonPropertyName("created")]
    public IEnumerable<AdminAttribute> Created { get; set; } = new List<AdminAttribute>();

    /// <summary>
    /// Array of issues encountered during attribute creation.
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
