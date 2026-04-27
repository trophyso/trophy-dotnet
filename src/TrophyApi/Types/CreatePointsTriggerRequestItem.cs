using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A points trigger to create.
/// </summary>
[Serializable]
public record CreatePointsTriggerRequestItem
{
    /// <summary>
    /// The type of trigger.
    /// </summary>
    [JsonPropertyName("type")]
    public required CreatePointsTriggerRequestItemType Type { get; set; }

    /// <summary>
    /// The number of points to award or deduct when the trigger fires. Cannot be zero.
    /// </summary>
    [JsonPropertyName("points")]
    public required int Points { get; set; }

    /// <summary>
    /// The status of the trigger. Defaults to 'inactive'.
    /// </summary>
    [JsonPropertyName("status")]
    public CreatePointsTriggerRequestItemStatus? Status { get; set; }

    /// <summary>
    /// Optional user attribute filters for the trigger.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<CreatePointsTriggerRequestItemUserAttributesItem>? UserAttributes { get; set; }

    /// <summary>
    /// Required if type is `metric`. The UUID of the metric.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// Required if type is `metric`. The metric increment that triggers the points.
    /// </summary>
    [JsonPropertyName("metricThreshold")]
    public int? MetricThreshold { get; set; }

    /// <summary>
    /// Optional event attribute filters. Only permitted if type is `metric`.
    /// </summary>
    [JsonPropertyName("eventAttributes")]
    public IEnumerable<CreatePointsTriggerRequestItemEventAttributesItem>? EventAttributes { get; set; }

    /// <summary>
    /// Required if type is `achievement`. The UUID of the achievement.
    /// </summary>
    [JsonPropertyName("achievementId")]
    public string? AchievementId { get; set; }

    /// <summary>
    /// Required if type is `streak`. The number of streak periods that triggers the points.
    /// </summary>
    [JsonPropertyName("streakLength")]
    public int? StreakLength { get; set; }

    /// <summary>
    /// Required if type is `time`. The unit for the time interval.
    /// </summary>
    [JsonPropertyName("timeUnit")]
    public CreatePointsTriggerRequestItemTimeUnit? TimeUnit { get; set; }

    /// <summary>
    /// Required if type is `time`. The number of time units between recurring awards.
    /// </summary>
    [JsonPropertyName("timeInterval")]
    public int? TimeInterval { get; set; }

    /// <summary>
    /// Whether to block metric events that would reduce the user's points below zero. Defaults to false.
    /// </summary>
    [JsonPropertyName("blockIfOutOfPoints")]
    public bool? BlockIfOutOfPoints { get; set; }

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
