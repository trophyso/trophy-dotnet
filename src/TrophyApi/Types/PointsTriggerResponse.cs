using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record PointsTriggerResponse
{
    /// <summary>
    /// The unique ID of the trigger.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The type of trigger.
    /// </summary>
    [JsonPropertyName("type")]
    public required PointsTriggerResponseType Type { get; set; }

    /// <summary>
    /// The points awarded by this trigger.
    /// </summary>
    [JsonPropertyName("points")]
    public required int Points { get; set; }

    /// <summary>
    /// The status of the trigger.
    /// </summary>
    [JsonPropertyName("status")]
    public required PointsTriggerResponseStatus Status { get; set; }

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
    /// The amount that a user must increase the metric to earn the points, if the trigger is a metric.
    /// </summary>
    [JsonPropertyName("metricThreshold")]
    public int? MetricThreshold { get; set; }

    /// <summary>
    /// The number of consecutive streak periods that a user must complete to earn the points, if the trigger is a streak.
    /// </summary>
    [JsonPropertyName("streakLengthThreshold")]
    public int? StreakLengthThreshold { get; set; }

    /// <summary>
    /// The name of the metric associated with this trigger, if the trigger is a metric.
    /// </summary>
    [JsonPropertyName("metricName")]
    public string? MetricName { get; set; }

    /// <summary>
    /// The name of the achievement associated with this trigger, if the trigger is an achievement.
    /// </summary>
    [JsonPropertyName("achievementName")]
    public string? AchievementName { get; set; }

    /// <summary>
    /// The time unit of the trigger, if the trigger is a time interval.
    /// </summary>
    [JsonPropertyName("timeUnit")]
    public PointsTriggerResponseTimeUnit? TimeUnit { get; set; }

    /// <summary>
    /// The interval of the trigger in the time unit, if the trigger is a time interval.
    /// </summary>
    [JsonPropertyName("timeInterval")]
    public int? TimeInterval { get; set; }

    /// <summary>
    /// User attribute filters that must be met for this trigger to activate. Only present if the trigger has user attribute filters configured.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<PointsTriggerResponseUserAttributesItem>? UserAttributes { get; set; }

    /// <summary>
    /// Event attribute filter that must be met for this trigger to activate. Only present if the trigger has an event filter configured.
    /// </summary>
    [JsonPropertyName("eventAttribute")]
    public PointsTriggerResponseEventAttribute? EventAttribute { get; set; }

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
