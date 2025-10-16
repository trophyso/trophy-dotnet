using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing any issues encountered while creating streak freezes.
/// </summary>
[Serializable]
public record CreateStreakFreezesResponse
{
    /// <summary>
    /// Array of issues encountered during freeze creation.
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
