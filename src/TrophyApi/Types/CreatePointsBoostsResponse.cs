using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing created boosts and any issues encountered while creating points boosts.
/// </summary>
[Serializable]
public record CreatePointsBoostsResponse
{
    /// <summary>
    /// Array of successfully created boosts.
    /// </summary>
    [JsonPropertyName("created")]
    public IEnumerable<CreatedPointsBoost> Created { get; set; } = new List<CreatedPointsBoost>();

    /// <summary>
    /// Array of issues encountered during boost creation.
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
