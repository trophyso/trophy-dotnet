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

    [JsonPropertyName("trigger")]
    public PointsTrigger? Trigger { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
