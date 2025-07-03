using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

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
    public double? Points { get; set; }

    /// <summary>
    /// If the trigger has type 'metric', the name of the metric
    /// </summary>
    [JsonPropertyName("metricName")]
    public string? MetricName { get; set; }

    /// <summary>
    /// If the trigger has type 'metric', the threshold of the metric that triggers the points
    /// </summary>
    [JsonPropertyName("metricThreshold")]
    public double? MetricThreshold { get; set; }

    /// <summary>
    /// If the trigger has type 'streak', the threshold of the streak that triggers the points
    /// </summary>
    [JsonPropertyName("streakLengthThreshold")]
    public double? StreakLengthThreshold { get; set; }

    /// <summary>
    /// If the trigger has type 'achievement', the name of the achievement
    /// </summary>
    [JsonPropertyName("achievementName")]
    public string? AchievementName { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
