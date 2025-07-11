using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record PointsAward
{
    /// <summary>
    /// The ID of the trigger award
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The points awarded by this trigger
    /// </summary>
    [JsonPropertyName("awarded")]
    public double? Awarded { get; set; }

    /// <summary>
    /// The date these points were awarded, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    /// <summary>
    /// The user's total points after this award occurred.
    /// </summary>
    [JsonPropertyName("total")]
    public double? Total { get; set; }

    [JsonPropertyName("trigger")]
    public PointsTrigger? Trigger { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
