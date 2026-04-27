using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A points trigger as returned from admin endpoints.
/// </summary>
[Serializable]
public record AdminPointsTrigger
{
    /// <summary>
    /// The UUID of the trigger.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The type of trigger.
    /// </summary>
    [JsonPropertyName("type")]
    public required AdminPointsTriggerType Type { get; set; }

    /// <summary>
    /// The number of points awarded or deducted when the trigger fires.
    /// </summary>
    [JsonPropertyName("points")]
    public required int Points { get; set; }

    /// <summary>
    /// The status of the trigger.
    /// </summary>
    [JsonPropertyName("status")]
    public required AdminPointsTriggerStatus Status { get; set; }

    /// <summary>
    /// User attribute filters applied to the trigger.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<AdminPointsTriggerUserAttributesItem> UserAttributes { get; set; } =
        new List<AdminPointsTriggerUserAttributesItem>();

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
    public IEnumerable<AdminPointsTriggerEventAttributesItem>? EventAttributes { get; set; }

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
    /// The time unit. Only present for time triggers.
    /// </summary>
    [JsonPropertyName("timeUnit")]
    public AdminPointsTriggerTimeUnit? TimeUnit { get; set; }

    /// <summary>
    /// The time interval. Only present for time triggers.
    /// </summary>
    [JsonPropertyName("timeInterval")]
    public int? TimeInterval { get; set; }

    /// <summary>
    /// Whether metric events that would reduce the user's points below zero are blocked.
    /// </summary>
    [JsonPropertyName("blockIfOutOfPoints")]
    public required bool BlockIfOutOfPoints { get; set; }

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
