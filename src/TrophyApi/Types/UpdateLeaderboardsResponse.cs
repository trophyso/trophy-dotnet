using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing updated leaderboards and any per-item issues identified by leaderboard ID.
/// </summary>
[Serializable]
public record UpdateLeaderboardsResponse
{
    /// <summary>
    /// Array of successfully updated leaderboards.
    /// </summary>
    [JsonPropertyName("updated")]
    public IEnumerable<AdminLeaderboard> Updated { get; set; } = new List<AdminLeaderboard>();

    /// <summary>
    /// Array of issues encountered during leaderboard update.
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
