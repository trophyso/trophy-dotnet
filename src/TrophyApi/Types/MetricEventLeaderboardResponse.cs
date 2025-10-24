using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record MetricEventLeaderboardResponse
{
    /// <summary>
    /// The end date of the current run of the leaderboard, or null if the run never ends.
    /// </summary>
    [JsonPropertyName("end")]
    public string? End { get; set; }

    /// <summary>
    /// The user's rank in the leaderboard, or null if the user is not on the leaderboard.
    /// </summary>
    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

    /// <summary>
    /// The user's rank in the leaderboard before the event, or null if the user was not on the leaderboard before the event.
    /// </summary>
    [JsonPropertyName("previousRank")]
    public int? PreviousRank { get; set; }

    /// <summary>
    /// The minimum value required to enter the leaderboard according to its current rankings.
    /// </summary>
    [JsonPropertyName("threshold")]
    public required int Threshold { get; set; }

    /// <summary>
    /// For leaderboards with a breakdown attribute, the value of the attribute for the user.
    /// </summary>
    [JsonPropertyName("breakdownAttributeValue")]
    public string? BreakdownAttributeValue { get; set; }

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
    public required string Description { get; set; }

    /// <summary>
    /// The start date of the leaderboard in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("start")]
    public required string Start { get; set; }

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
    /// The interval between repetitions, relative to the start date and repetition type.
    /// </summary>
    [JsonPropertyName("runInterval")]
    public required int RunInterval { get; set; }

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
