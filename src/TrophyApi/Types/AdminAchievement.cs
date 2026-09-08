using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// An achievement as returned from admin endpoints. Trigger-specific fields are only present for the matching trigger type.
/// </summary>
[Serializable]
public record AdminAchievement : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the achievement.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The achievement name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A short description of the achievement.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The achievement trigger type.
    /// </summary>
    [JsonPropertyName("trigger")]
    public required AdminAchievementTrigger Trigger { get; set; }

    /// <summary>
    /// The achievement status.
    /// </summary>
    [JsonPropertyName("status")]
    public required AdminAchievementStatus Status { get; set; }

    /// <summary>
    /// The badge for the achievement, or null if no badge is set.
    /// </summary>
    [JsonPropertyName("badge")]
    public AdminAchievementBadge? Badge { get; set; }

    /// <summary>
    /// User attribute filters applied to the achievement.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<AdminAchievementUserAttributesItem> UserAttributes { get; set; } =
        new List<AdminAchievementUserAttributesItem>();

    /// <summary>
    /// The achievement key. Only present for API achievements.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// The UUID of the metric. Only present for metric achievements.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// The metric threshold. Only present for metric achievements.
    /// </summary>
    [JsonPropertyName("metricValue")]
    public double? MetricValue { get; set; }

    /// <summary>
    /// Event attribute filters. Only present for metric achievements.
    /// </summary>
    [JsonPropertyName("eventAttributes")]
    public IEnumerable<AdminAchievementEventAttributesItem>? EventAttributes { get; set; }

    /// <summary>
    /// The streak length. Only present for streak achievements.
    /// </summary>
    [JsonPropertyName("streakLength")]
    public int? StreakLength { get; set; }

    /// <summary>
    /// The anniversary years. Only present for anniversary achievements.
    /// </summary>
    [JsonPropertyName("anniversaryYears")]
    public int? AnniversaryYears { get; set; }

    /// <summary>
    /// Prerequisite achievement UUIDs. Only present for achievement achievements.
    /// </summary>
    [JsonPropertyName("achievementIds")]
    public IEnumerable<string>? AchievementIds { get; set; }

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
