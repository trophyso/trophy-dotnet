using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record MetricEventPointsResponse
{
    /// <summary>
    /// The points added by this event.
    /// </summary>
    [JsonPropertyName("added")]
    public double? Added { get; set; }

    /// <summary>
    /// The ID of the points system
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name of the points system
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The description of the points system
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The URL of the badge image for the points system
    /// </summary>
    [JsonPropertyName("badgeUrl")]
    public string? BadgeUrl { get; set; }

    /// <summary>
    /// The user's total points
    /// </summary>
    [JsonPropertyName("total")]
    public required double Total { get; set; }

    /// <summary>
    /// Array of trigger awards that added points.
    /// </summary>
    [JsonPropertyName("awards")]
    public IEnumerable<PointsAward> Awards { get; set; } = new List<PointsAward>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
