using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// The user's most active day during the year.
/// </summary>
[Serializable]
public record WrappedMostActiveDay : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
