using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// The user's activity summary for the wrapped year.
/// </summary>
[Serializable]
public record WrappedActivity : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
