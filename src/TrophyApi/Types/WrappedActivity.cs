using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// The user's activity summary for the wrapped year.
/// </summary>
[Serializable]
public record WrappedActivity
{
    /// <summary>
    /// The number of days the user was active during the year.
    /// </summary>
    [JsonPropertyName("daysActive")]
    public required int DaysActive { get; set; }

    /// <summary>
    /// The number of weeks the user was active during the year.
    /// </summary>
    [JsonPropertyName("weeksActive")]
    public required int WeeksActive { get; set; }

    /// <summary>
    /// The number of months the user was active during the year.
    /// </summary>
    [JsonPropertyName("monthsActive")]
    public required int MonthsActive { get; set; }

    /// <summary>
    /// Data about the user's most active day.
    /// </summary>
    [JsonPropertyName("mostActiveDay")]
    public required WrappedMostActiveDay MostActiveDay { get; set; }

    /// <summary>
    /// Data about the user's most active week.
    /// </summary>
    [JsonPropertyName("mostActiveWeek")]
    public required WrappedMostActiveWeek MostActiveWeek { get; set; }

    /// <summary>
    /// Data about the user's most active month.
    /// </summary>
    [JsonPropertyName("mostActiveMonth")]
    public required WrappedMostActiveMonth MostActiveMonth { get; set; }

    /// <summary>
    /// Data about the user's activity for the entire year.
    /// </summary>
    [JsonPropertyName("entireYear")]
    public required WrappedEntireYear EntireYear { get; set; }

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
