using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing updated boosts and any issues encountered.
/// </summary>
[Serializable]
public record PatchPointsBoostsResponse
{
    /// <summary>
    /// Array of successfully updated boosts.
    /// </summary>
    [JsonPropertyName("updated")]
    public IEnumerable<AdminPointsBoost> Updated { get; set; } = new List<AdminPointsBoost>();

    /// <summary>
    /// Array of issues encountered during boost updates.
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
