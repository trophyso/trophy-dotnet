using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A user's data for a specific leaderboard including rank, value, and history.
/// </summary>
[Serializable]
public record WebhookUserLeaderboardResponse
{
    /// <summary>
    /// The user's rank before this event, or null if they were not on the leaderboard.
    /// </summary>
    [JsonPropertyName("previousRank")]
    public int? PreviousRank { get; set; }

    /// <summary>
    /// The user's value before this event, or null if they were not on the leaderboard.
    /// </summary>
    [JsonPropertyName("previousValue")]
    public int? PreviousValue { get; set; }

    /// <summary>
    /// The user's current rank in this leaderboard. Null if the user is not on the leaderboard.
    /// </summary>
    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

    /// <summary>
    /// The user's current value in this leaderboard. Null if the user is not on the leaderboard.
    /// </summary>
    [JsonPropertyName("value")]
    public int? Value { get; set; }

    /// <summary>
    /// The unique ID of the leaderboard.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The user-facing name of the leaderboard.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The unique key used to reference the leaderboard in APIs.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// What the leaderboard ranks by.
    /// </summary>
    [JsonPropertyName("rankBy")]
    public required LeaderboardResponseRankBy RankBy { get; set; }

    /// <summary>
    /// The key of the attribute to break down this leaderboard by.
    /// </summary>
    [JsonPropertyName("breakdownAttribute")]
    public string? BreakdownAttribute { get; set; }

    /// <summary>
    /// The key of the metric to rank by, if rankBy is 'metric'.
    /// </summary>
    [JsonPropertyName("metricKey")]
    public string? MetricKey { get; set; }

    /// <summary>
    /// The name of the metric to rank by, if rankBy is 'metric'.
    /// </summary>
    [JsonPropertyName("metricName")]
    public string? MetricName { get; set; }

    /// <summary>
    /// The key of the points system to rank by, if rankBy is 'points'.
    /// </summary>
    [JsonPropertyName("pointsSystemKey")]
    public string? PointsSystemKey { get; set; }

    /// <summary>
    /// The name of the points system to rank by, if rankBy is 'points'.
    /// </summary>
    [JsonPropertyName("pointsSystemName")]
    public string? PointsSystemName { get; set; }

    /// <summary>
    /// The user-facing description of the leaderboard.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The start date of the leaderboard in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("start")]
    public required string Start { get; set; }

    /// <summary>
    /// The end date of the leaderboard in YYYY-MM-DD format, or null if it runs forever.
    /// </summary>
    [JsonPropertyName("end")]
    public string? End { get; set; }

    /// <summary>
    /// The maximum number of participants in the leaderboard.
    /// </summary>
    [JsonPropertyName("maxParticipants")]
    public required int MaxParticipants { get; set; }

    /// <summary>
    /// The repetition type for recurring leaderboards, or null for one-time leaderboards.
    /// </summary>
    [JsonPropertyName("runUnit")]
    public LeaderboardResponseRunUnit? RunUnit { get; set; }

    /// <summary>
    /// The interval between repetitions, relative to the start date and repetition type. Null for one-time leaderboards.
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
