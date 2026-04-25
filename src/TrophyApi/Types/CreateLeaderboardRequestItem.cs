using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A leaderboard to create.
/// </summary>
[Serializable]
public record CreateLeaderboardRequestItem
{
    /// <summary>
    /// The leaderboard name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The leaderboard key. Only alphanumeric characters, hyphens, and underscores are permitted.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// The leaderboard description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The initial user-facing status. Defaults to `inactive`. Use `scheduled` for leaderboards that should be active in the future and `finished` only when creating a leaderboard with an end date in the past.
    /// </summary>
    [JsonPropertyName("status")]
    public CreateLeaderboardRequestItemStatus? Status { get; set; }

    /// <summary>
    /// What the leaderboard ranks by.
    /// </summary>
    [JsonPropertyName("rankBy")]
    public required CreateLeaderboardRequestItemRankBy RankBy { get; set; }

    /// <summary>
    /// The metric ID to rank by when `rankBy` is `metric`.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// The points system ID to rank by when `rankBy` is `points`.
    /// </summary>
    [JsonPropertyName("pointsSystemId")]
    public string? PointsSystemId { get; set; }

    /// <summary>
    /// The maximum number of participants. Defaults to `1000`.
    /// </summary>
    [JsonPropertyName("maxParticipants")]
    public int? MaxParticipants { get; set; }

    /// <summary>
    /// The leaderboard start date in YYYY-MM-DD format. Defaults to today when omitted.
    /// </summary>
    [JsonPropertyName("start")]
    public string? Start { get; set; }

    /// <summary>
    /// The optional leaderboard end date in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("end")]
    public string? End { get; set; }

    /// <summary>
    /// The UUIDs of the active user attributes to break rankings down by.
    /// </summary>
    [JsonPropertyName("breakdownAttributes")]
    public IEnumerable<string>? BreakdownAttributes { get; set; }

    /// <summary>
    /// How often the leaderboard repeats. Omit for a non-recurring leaderboard. Streak leaderboards cannot repeat.
    /// </summary>
    [JsonPropertyName("runUnit")]
    public CreateLeaderboardRequestItemRunUnit? RunUnit { get; set; }

    /// <summary>
    /// The number of `runUnit`s between repeats. Required when `runUnit` is set.
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
