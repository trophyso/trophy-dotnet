using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A points trigger to create.
/// </summary>
[Serializable]
public record CreatePointsTriggerRequestItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
