using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record IncrementMetricStreakResponse
{
    /// <summary>
    /// Whether this metric event increased the user's streak length.
    /// </summary>
    [JsonPropertyName("extended")]
    public bool? Extended { get; set; }

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

    /// <summary>
    /// The date the streak started.
    /// </summary>
    [JsonPropertyName("started")]
    public string? Started { get; set; }

    /// <summary>
    /// The start date of the current streak period.
    /// </summary>
    [JsonPropertyName("periodStart")]
    public string? PeriodStart { get; set; }

    /// <summary>
    /// The end date of the current streak period.
    /// </summary>
    [JsonPropertyName("periodEnd")]
    public string? PeriodEnd { get; set; }

    /// <summary>
    /// The date the streak will expire if the user does not increment a metric.
    /// </summary>
    [JsonPropertyName("expires")]
    public string? Expires { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
