using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record LeaderboardsAllResponseItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The status of the leaderboard.
    /// </summary>
    [JsonPropertyName("status")]
    public required LeaderboardsAllResponseItemStatus Status { get; set; }

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
    /// Deprecated. The key of the attribute to break down this leaderboard by.
    /// </summary>
    [JsonPropertyName("breakdownAttribute")]
    public string? BreakdownAttribute { get; set; }

    /// <summary>
    /// The user attribute keys that this leaderboard is broken down by.
    /// </summary>
    [JsonPropertyName("breakdownAttributes")]
    public IEnumerable<string> BreakdownAttributes { get; set; } = new List<string>();

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
    public int? MaxParticipants { get; set; }

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
