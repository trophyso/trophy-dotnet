using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// The trigger that awarded the reward, as it is configured now. Only the fields for the trigger's current type are included.
/// </summary>
[Serializable]
public record UserRewardTrigger : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public required UserRewardTriggerType Type { get; set; }

    /// <summary>
    /// For metric triggers, the ID of the metric.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// For metric triggers, the reward is awarded each time the user's total for the metric increases by this amount.
    /// </summary>
    [JsonPropertyName("metricThreshold")]
    public int? MetricThreshold { get; set; }

    /// <summary>
    /// For achievement triggers, the ID of the achievement.
    /// </summary>
    [JsonPropertyName("achievementId")]
    public string? AchievementId { get; set; }

    /// <summary>
    /// For streak triggers, the reward is awarded every this many periods of the user's streak.
    /// </summary>
    [JsonPropertyName("streakLengthThreshold")]
    public int? StreakLengthThreshold { get; set; }

    /// <summary>
    /// For leaderboard triggers, the ID of the leaderboard.
    /// </summary>
    [JsonPropertyName("leaderboardId")]
    public string? LeaderboardId { get; set; }

    /// <summary>
    /// For leaderboard triggers, the rank a user must finish a leaderboard run at.
    /// </summary>
    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

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
