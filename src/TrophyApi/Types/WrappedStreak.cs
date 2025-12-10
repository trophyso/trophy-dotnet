using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// The user's longest streak during the wrapped period.
/// </summary>
[Serializable]
public record WrappedStreak
{
    /// <summary>
    /// The length of the streak.
    /// </summary>
    [JsonPropertyName("length")]
    public required int Length { get; set; }

    /// <summary>
    /// The frequency of the streak.
    /// </summary>
    [JsonPropertyName("frequency")]
    public required StreakFrequency Frequency { get; set; }

    /// <summary>
    /// The start date of the streak period.
    /// </summary>
    [JsonPropertyName("periodStart")]
    public string? PeriodStart { get; set; }

    /// <summary>
    /// The end date of the streak period.
    /// </summary>
    [JsonPropertyName("periodEnd")]
    public string? PeriodEnd { get; set; }

    /// <summary>
    /// The date the streak started.
    /// </summary>
    [JsonPropertyName("started")]
    public string? Started { get; set; }

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
