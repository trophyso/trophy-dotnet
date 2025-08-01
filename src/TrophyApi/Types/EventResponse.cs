using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record EventResponse
{
    /// <summary>
    /// The unique ID of the event.
    /// </summary>
    [JsonPropertyName("eventId")]
    public required string EventId { get; set; }

    /// <summary>
    /// The unique ID of the metric that was updated.
    /// </summary>
    [JsonPropertyName("metricId")]
    public required string MetricId { get; set; }

    /// <summary>
    /// The user's new total progress against the metric.
    /// </summary>
    [JsonPropertyName("total")]
    public required double Total { get; set; }

    /// <summary>
    /// Achievements completed as a result of this event.
    /// </summary>
    [JsonPropertyName("achievements")]
    public IEnumerable<CompletedAchievementResponse>? Achievements { get; set; }

    /// <summary>
    /// The user's current streak for the metric, if the metric has streaks enabled.
    /// </summary>
    [JsonPropertyName("currentStreak")]
    public MetricEventStreakResponse? CurrentStreak { get; set; }

    /// <summary>
    /// The points added by this event, and a breakdown of the points awards that added points.
    /// </summary>
    [JsonPropertyName("points")]
    public MetricEventPointsResponse? Points { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
