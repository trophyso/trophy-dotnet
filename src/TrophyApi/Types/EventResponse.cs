using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
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
    public IEnumerable<UserAchievementResponse> Achievements { get; set; } =
        new List<UserAchievementResponse>();

    /// <summary>
    /// The user's current streak.
    /// </summary>
    [JsonPropertyName("currentStreak")]
    public required MetricEventStreakResponse CurrentStreak { get; set; }

    /// <summary>
    /// A map of points systems by key. Only contains points systems that were affected by the event.
    /// </summary>
    [JsonPropertyName("points")]
    public Dictionary<string, MetricEventPointsResponse> Points { get; set; } =
        new Dictionary<string, MetricEventPointsResponse>();

    /// <summary>
    /// A map of leaderboards by key. Only contains leaderboards that were affected by the event.
    /// </summary>
    [JsonPropertyName("leaderboards")]
    public Dictionary<string, MetricEventLeaderboardResponse> Leaderboards { get; set; } =
        new Dictionary<string, MetricEventLeaderboardResponse>();

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
