using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record PointsTrigger
{
    /// <summary>
    /// The ID of the trigger
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The type of trigger
    /// </summary>
    [JsonPropertyName("type")]
    public required PointsTriggerType Type { get; set; }

    /// <summary>
    /// The points awarded by this trigger.
    /// </summary>
    [JsonPropertyName("points")]
    public required int Points { get; set; }

    /// <summary>
    /// The status of the trigger.
    /// </summary>
    [JsonPropertyName("status")]
    public required PointsTriggerStatus Status { get; set; }

    /// <summary>
    /// The unique ID of the achievement associated with this trigger, if the trigger is an achievement.
    /// </summary>
    [JsonPropertyName("achievementId")]
    public string? AchievementId { get; set; }

    /// <summary>
    /// The unique ID of the metric associated with this trigger, if the trigger is a metric.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// If the trigger has type 'metric', the name of the metric
    /// </summary>
    [JsonPropertyName("metricName")]
    public string? MetricName { get; set; }

    /// <summary>
    /// If the trigger has type 'metric', the threshold of the metric that triggers the points
    /// </summary>
    [JsonPropertyName("metricThreshold")]
    public int? MetricThreshold { get; set; }

    /// <summary>
    /// If the trigger has type 'streak', the threshold of the streak that triggers the points
    /// </summary>
    [JsonPropertyName("streakLengthThreshold")]
    public int? StreakLengthThreshold { get; set; }

    /// <summary>
    /// If the trigger has type 'achievement', the name of the achievement
    /// </summary>
    [JsonPropertyName("achievementName")]
    public string? AchievementName { get; set; }

    /// <summary>
    /// If the trigger has type 'time', the unit of time after which to award points
    /// </summary>
    [JsonPropertyName("timeUnit")]
    public PointsTriggerTimeUnit? TimeUnit { get; set; }

    /// <summary>
    /// If the trigger has type 'time', the numer of units of timeUnit after which to award points
    /// </summary>
    [JsonPropertyName("timeInterval")]
    public int? TimeInterval { get; set; }

    /// <summary>
    /// User attribute filters that must be met for this trigger to award points. Empty when the trigger has no user attribute filters configured.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<PointsTriggerUserAttributesItem> UserAttributes { get; set; } =
        new List<PointsTriggerUserAttributesItem>();

    /// <summary>
    /// Deprecated. Event attribute filter that must be met for this trigger to award points. Only present if the trigger has an event filter configured.
    /// </summary>
    [JsonPropertyName("eventAttribute")]
    public PointsTriggerEventAttribute? EventAttribute { get; set; }

    /// <summary>
    /// If the trigger has type 'metric', the event attributes that must match for the trigger to award points. Empty when the trigger is metric-based and has no event attribute filters. Omitted for non-metric triggers.
    /// </summary>
    [JsonPropertyName("eventAttributes")]
    public IEnumerable<PointsTriggerEventAttributesItem>? EventAttributes { get; set; }

    /// <summary>
    /// The date and time the trigger was created, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("created")]
    public required DateTime Created { get; set; }

    /// <summary>
    /// The date and time the trigger was last updated, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("updated")]
    public required DateTime Updated { get; set; }

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
