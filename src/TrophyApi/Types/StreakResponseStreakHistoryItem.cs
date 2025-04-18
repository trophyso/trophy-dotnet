using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record StreakResponseStreakHistoryItem
{
    /// <summary>
    /// The date this streak period started.
    /// </summary>
    [JsonPropertyName("periodStart")]
    public required string PeriodStart { get; set; }

    /// <summary>
    /// The date this streak period ended.
    /// </summary>
    [JsonPropertyName("periodEnd")]
    public required string PeriodEnd { get; set; }

    /// <summary>
    /// The length of the user's streak during this period.
    /// </summary>
    [JsonPropertyName("length")]
    public required int Length { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
