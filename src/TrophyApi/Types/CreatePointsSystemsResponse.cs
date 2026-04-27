using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing created points systems and any per-item issues.
/// </summary>
[Serializable]
public record CreatePointsSystemsResponse
{
    /// <summary>
    /// Array of successfully created points systems.
    /// </summary>
    [JsonPropertyName("created")]
    public IEnumerable<CreatedAdminPointsSystem> Created { get; set; } =
        new List<CreatedAdminPointsSystem>();

    /// <summary>
    /// Array of issues encountered during creation.
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
