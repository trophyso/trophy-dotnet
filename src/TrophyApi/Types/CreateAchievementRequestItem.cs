using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// An achievement to create. Trigger-specific fields are required based on `trigger`. `status` defaults to `inactive`.
/// </summary>
[Serializable]
public record CreateAchievementRequestItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The achievement name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The achievement trigger type.
    /// </summary>
    [JsonPropertyName("trigger")]
    public required CreateAchievementRequestItemTrigger Trigger { get; set; }

    /// <summary>
    /// A short description of the achievement.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The achievement status. Defaults to `inactive`.
    /// </summary>
    [JsonPropertyName("status")]
    public CreateAchievementRequestItemStatus? Status { get; set; }

    /// <summary>
    /// An optional badge for the achievement.
    /// </summary>
    [JsonPropertyName("badge")]
    public CreateAchievementRequestItemBadge? Badge { get; set; }

    /// <summary>
    /// User attribute filters applied to the achievement. Each `attributeId` must be an active user attribute.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<CreateAchievementRequestItemUserAttributesItem>? UserAttributes { get; set; }

    /// <summary>
    /// Required if trigger is `api`. Only alphanumeric characters, hyphens, and underscores are permitted.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// Required if trigger is `metric`. The UUID of the metric.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// Required if trigger is `metric`. The metric threshold users must reach. Must be at least 1.
    /// </summary>
    [JsonPropertyName("metricValue")]
    public double? MetricValue { get; set; }

    /// <summary>
    /// Event attribute filters. Only permitted for metric achievements. Each `attributeId` must be an active event attribute.
    /// </summary>
    [JsonPropertyName("eventAttributes")]
    public IEnumerable<CreateAchievementRequestItemEventAttributesItem>? EventAttributes { get; set; }

    /// <summary>
    /// Required if trigger is `streak`. The streak length users must reach. Must be at least 1.
    /// </summary>
    [JsonPropertyName("streakLength")]
    public int? StreakLength { get; set; }

    /// <summary>
    /// Required if trigger is `anniversary`. The number of years since sign-up. Must be at least 1.
    /// </summary>
    [JsonPropertyName("anniversaryYears")]
    public int? AnniversaryYears { get; set; }

    /// <summary>
    /// Required if trigger is `achievement`. UUIDs of prerequisite achievements.
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
