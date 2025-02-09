using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record StreakResponse
{
    /// <summary>
    /// The length of the user's current streak.
    /// </summary>
    [JsonPropertyName("length")]
    public required int Length { get; set; }

    /// <summary>
    /// The frequency of the streak.
    /// </summary>
    [JsonPropertyName("frequency")]
    public required StreakFrequency Frequency { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
