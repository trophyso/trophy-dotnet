using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A leaderboard returned from the admin leaderboards endpoints.
/// </summary>
[Serializable]
public record AdminLeaderboard
{
    /// <summary>
    /// The UUID of the leaderboard.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The leaderboard name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The leaderboard key.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// The leaderboard description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The current user-facing status of the leaderboard.
    /// </summary>
    [JsonPropertyName("status")]
    public required AdminLeaderboardStatus Status { get; set; }

    /// <summary>
    /// What the leaderboard ranks by.
    /// </summary>
    [JsonPropertyName("rankBy")]
    public required AdminLeaderboardRankBy RankBy { get; set; }

    /// <summary>
    /// The metric ID used when `rankBy` is `metric`.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// The points system ID used when `rankBy` is `points`.
    /// </summary>
    [JsonPropertyName("pointsSystemId")]
    public string? PointsSystemId { get; set; }

    /// <summary>
    /// The maximum number of participants.
    /// </summary>
    [JsonPropertyName("maxParticipants")]
    public required int MaxParticipants { get; set; }

    /// <summary>
    /// The leaderboard start date in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("start")]
    public required string Start { get; set; }

    /// <summary>
    /// The optional leaderboard end date in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("end")]
    public string? End { get; set; }

    /// <summary>
    /// The UUIDs of the user attributes used for ranking breakdowns.
    /// </summary>
    [JsonPropertyName("breakdownAttributes")]
    public IEnumerable<string> BreakdownAttributes { get; set; } = new List<string>();

    /// <summary>
    /// The recurrence unit when the leaderboard repeats.
    /// </summary>
    [JsonPropertyName("runUnit")]
    public AdminLeaderboardRunUnit? RunUnit { get; set; }

    /// <summary>
    /// The number of recurrence units between leaderboard runs.
    /// </summary>
    [JsonPropertyName("runInterval")]
    public int? RunInterval { get; set; }

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
