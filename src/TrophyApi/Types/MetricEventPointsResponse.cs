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
    /// The user's total points
    /// </summary>
    [JsonPropertyName("total")]
    public double? Total { get; set; }

    /// <summary>
    /// Array of trigger awards that added points.
    /// </summary>
    [JsonPropertyName("awards")]
    public IEnumerable<PointsAward>? Awards { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
