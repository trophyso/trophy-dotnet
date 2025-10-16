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
    public string? Id { get; set; }

    /// <summary>
    /// The type of trigger
    /// </summary>
    [JsonPropertyName("type")]
    public PointsTriggerType? Type { get; set; }

    /// <summary>
    /// The points awarded by this trigger.
    /// </summary>
    [JsonPropertyName("points")]
    public int? Points { get; set; }

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
