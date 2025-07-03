using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record GetUserPointsResponse
{
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
