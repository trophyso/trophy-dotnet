using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// The user's most active day during the year.
/// </summary>
[Serializable]
public record WrappedMostActiveDay
{
    /// <summary>
    /// The date of the most active day in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("date")]
    public required string Date { get; set; }

    /// <summary>
    /// The user's metrics during this period, keyed by metric key.
    /// </summary>
    [JsonPropertyName("metrics")]
    public Dictionary<string, WrappedMetric> Metrics { get; set; } =
        new Dictionary<string, WrappedMetric>();

    /// <summary>
    /// The user's points during this period, keyed by points system key.
    /// </summary>
    [JsonPropertyName("points")]
    public Dictionary<string, WrappedPoints> Points { get; set; } =
        new Dictionary<string, WrappedPoints>();

    /// <summary>
    /// Achievements completed during this period.
    /// </summary>
    [JsonPropertyName("achievements")]
    public IEnumerable<UserAchievementResponse> Achievements { get; set; } =
        new List<UserAchievementResponse>();

    /// <summary>
    /// The user's best leaderboard rankings during this period, keyed by leaderboard key.
    /// </summary>
    [JsonPropertyName("leaderboards")]
    public Dictionary<string, UserLeaderboardResponse> Leaderboards { get; set; } =
        new Dictionary<string, UserLeaderboardResponse>();

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
