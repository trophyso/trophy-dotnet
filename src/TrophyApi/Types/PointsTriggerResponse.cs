using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record PointsTriggerResponse
{
    /// <summary>
    /// The unique ID of the trigger.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The type of trigger.
    /// </summary>
    [JsonPropertyName("type")]
    public PointsTriggerResponseType? Type { get; set; }

    /// <summary>
    /// The points awarded by this trigger.
    /// </summary>
    [JsonPropertyName("points")]
    public double? Points { get; set; }

    /// <summary>
    /// The status of the trigger.
    /// </summary>
    [JsonPropertyName("status")]
    public PointsTriggerResponseStatus? Status { get; set; }

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
    public double? MetricThreshold { get; set; }

    /// <summary>
    /// The number of consecutive streak periods that a user must complete to earn the points, if the trigger is a streak.
    /// </summary>
    [JsonPropertyName("streakLengthThreshold")]
    public double? StreakLengthThreshold { get; set; }

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
    /// The date and time the trigger was created, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    /// <summary>
    /// The date and time the trigger was last updated, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("updated")]
    public DateTime? Updated { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
