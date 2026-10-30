using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A reward trigger to create.
/// </summary>
[Serializable]
public record CreateRewardTriggerRequestItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The type of trigger.
    /// </summary>
    [JsonPropertyName("type")]
    public required CreateRewardTriggerRequestItemType Type { get; set; }

    /// <summary>
    /// The status of the trigger. Defaults to 'inactive'.
    /// </summary>
    [JsonPropertyName("status")]
    public CreateRewardTriggerRequestItemStatus? Status { get; set; }

    /// <summary>
    /// Optional user attribute filters for the trigger.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<CreateRewardTriggerRequestItemUserAttributesItem>? UserAttributes { get; set; }

    /// <summary>
    /// Required if type is `metric`. The UUID of the metric.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// Required if type is `metric`. The reward is awarded each time the user's metric total grows by this amount.
    /// </summary>
    [JsonPropertyName("metricThreshold")]
    public int? MetricThreshold { get; set; }

    /// <summary>
    /// Optional event attribute filters. Only permitted if type is `metric`.
    /// </summary>
    [JsonPropertyName("eventAttributes")]
    public IEnumerable<CreateRewardTriggerRequestItemEventAttributesItem>? EventAttributes { get; set; }

    /// <summary>
    /// Required if type is `achievement`. The UUID of the achievement.
    /// </summary>
    [JsonPropertyName("achievementId")]
    public string? AchievementId { get; set; }

    /// <summary>
    /// Required if type is `streak`. The number of streak periods that awards the reward. It is awarded again each time the streak grows by this many periods.
    /// </summary>
    [JsonPropertyName("streakLength")]
    public int? StreakLength { get; set; }

    /// <summary>
    /// Required if type is `leaderboard`. The UUID of the leaderboard.
    /// </summary>
    [JsonPropertyName("leaderboardId")]
    public string? LeaderboardId { get; set; }

    /// <summary>
    /// Required if type is `leaderboard`. The final rank that awards the reward.
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
