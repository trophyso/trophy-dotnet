using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record PointsRange
{
    /// <summary>
    /// The start of the points range. Inclusive.
    /// </summary>
    [JsonPropertyName("from")]
    public double? From { get; set; }

    /// <summary>
    /// The end of the points range. Inclusive.
    /// </summary>
    [JsonPropertyName("to")]
    public double? To { get; set; }

    /// <summary>
    /// The number of users in this points range.
    /// </summary>
    [JsonPropertyName("users")]
    public double? Users { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
