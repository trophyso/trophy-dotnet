using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record UserLeaderboardResponse
{
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
    /// An array of events showing the user's rank and value changes over time.
    /// </summary>
    [JsonPropertyName("history")]
    public IEnumerable<LeaderboardEvent> History { get; set; } = new List<LeaderboardEvent>();

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
    /// The status of the leaderboard.
    /// </summary>
    [JsonPropertyName("status")]
    public LeaderboardResponseStatus? Status { get; set; }

    /// <summary>
    /// What the leaderboard ranks by.
    /// </summary>
    [JsonPropertyName("rankBy")]
    public required LeaderboardResponseRankBy RankBy { get; set; }

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
    public string? RunUnit { get; set; }

    /// <summary>
    /// The interval between repetitions, relative to the start date and repetition type.
    /// </summary>
    [JsonPropertyName("runInterval")]
    public required int RunInterval { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
