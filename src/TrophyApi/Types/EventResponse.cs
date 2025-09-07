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
    /// A map of points systems by key that were affected by this event.
    /// </summary>
    [JsonPropertyName("points")]
    public Dictionary<string, MetricEventPointsResponse>? Points { get; set; }

    /// <summary>
    /// The idempotency key used for the event, if one was provided.
    /// </summary>
    [JsonPropertyName("idempotencyKey")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Whether the event was replayed due to idempotency.
    /// </summary>
    [JsonPropertyName("idempotentReplayed")]
    public bool? IdempotentReplayed { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
