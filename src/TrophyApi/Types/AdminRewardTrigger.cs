using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A reward trigger as returned from admin endpoints.
/// </summary>
[Serializable]
public record AdminRewardTrigger : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the trigger.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The type of trigger.
    /// </summary>
    [JsonPropertyName("type")]
    public required AdminRewardTriggerType Type { get; set; }

    /// <summary>
    /// The status of the trigger. Only active triggers award the reward.
    /// </summary>
    [JsonPropertyName("status")]
    public required AdminRewardTriggerStatus Status { get; set; }

    /// <summary>
    /// User attribute filters applied to the trigger.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<AdminRewardTriggerUserAttributesItem> UserAttributes { get; set; } =
        new List<AdminRewardTriggerUserAttributesItem>();

    /// <summary>
    /// The UUID of the metric. Only present for metric triggers.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// The metric threshold. Only present for metric triggers.
    /// </summary>
    [JsonPropertyName("metricThreshold")]
    public int? MetricThreshold { get; set; }

    /// <summary>
    /// Event attribute filters applied to the trigger. Only present for metric triggers.
    /// </summary>
    [JsonPropertyName("eventAttributes")]
    public IEnumerable<AdminRewardTriggerEventAttributesItem>? EventAttributes { get; set; }

    /// <summary>
    /// The UUID of the achievement. Only present for achievement triggers.
    /// </summary>
    [JsonPropertyName("achievementId")]
    public string? AchievementId { get; set; }

    /// <summary>
    /// The streak length. Only present for streak triggers.
    /// </summary>
    [JsonPropertyName("streakLength")]
    public int? StreakLength { get; set; }

    /// <summary>
    /// The UUID of the leaderboard. Only present for leaderboard triggers.
    /// </summary>
    [JsonPropertyName("leaderboardId")]
    public string? LeaderboardId { get; set; }

    /// <summary>
    /// The rank. Only present for leaderboard triggers.
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
