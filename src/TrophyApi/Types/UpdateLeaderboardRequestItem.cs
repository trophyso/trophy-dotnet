using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A leaderboard update object. `id` is required. Once a leaderboard has been activated, the dashboard-imposed restrictions on ranking configuration and scheduling changes still apply.
/// </summary>
[Serializable]
public record UpdateLeaderboardRequestItem
{
    /// <summary>
    /// The UUID of the leaderboard to update.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The updated leaderboard name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The updated leaderboard key. This can only be changed while the leaderboard is inactive.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// The updated leaderboard description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The target user-facing status. `scheduled` activates a leaderboard whose start date is in the future. `finished` behaves like the dashboard finish action.
    /// </summary>
    [JsonPropertyName("status")]
    public UpdateLeaderboardRequestItemStatus? Status { get; set; }

    /// <summary>
    /// The updated ranking criterion. This can only be changed while the leaderboard is inactive.
    /// </summary>
    [JsonPropertyName("rankBy")]
    public UpdateLeaderboardRequestItemRankBy? RankBy { get; set; }

    /// <summary>
    /// The metric ID to use when `rankBy` is `metric`.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// The points system ID to use when `rankBy` is `points`.
    /// </summary>
    [JsonPropertyName("pointsSystemId")]
    public string? PointsSystemId { get; set; }

    /// <summary>
    /// The updated maximum number of participants.
    /// </summary>
    [JsonPropertyName("maxParticipants")]
    public int? MaxParticipants { get; set; }

    /// <summary>
    /// The updated start date in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("start")]
    public string? Start { get; set; }

    /// <summary>
    /// The updated end date in YYYY-MM-DD format, or `null` to clear it.
    /// </summary>
    [JsonPropertyName("end")]
    public string? End { get; set; }

    /// <summary>
    /// The updated breakdown attribute UUIDs.
    /// </summary>
    [JsonPropertyName("breakdownAttributes")]
    public IEnumerable<string>? BreakdownAttributes { get; set; }

    /// <summary>
    /// The updated recurrence unit.
    /// </summary>
    [JsonPropertyName("runUnit")]
    public UpdateLeaderboardRequestItemRunUnit? RunUnit { get; set; }

    /// <summary>
    /// The updated recurrence interval.
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
