using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// The organization's streak configuration.
/// </summary>
[Serializable]
public record StreakSettings : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("frequency")]
    public required AdminStreakFrequency Frequency { get; set; }

    [JsonPropertyName("evaluationMode")]
    public required AdminStreakEvaluationMode EvaluationMode { get; set; }

    /// <summary>
    /// Whether users can override streak evaluation mode, metric thresholds, and days off via preferences.
    /// </summary>
    [JsonPropertyName("customizationEnabled")]
    public required bool CustomizationEnabled { get; set; }

    /// <summary>
    /// Days of the week that do not count toward the daily streak. Represented as zero-based integers matching JavaScript `Date.getDay()` (0 = Sunday, 6 = Saturday).
    /// </summary>
    [JsonPropertyName("daysOff")]
    public IEnumerable<int> DaysOff { get; set; } = new List<int>();

    /// <summary>
    /// Metrics with a streak threshold greater than zero.
    /// </summary>
    [JsonPropertyName("metrics")]
    public IEnumerable<StreakSettingsMetric> Metrics { get; set; } =
        new List<StreakSettingsMetric>();

    /// <summary>
    /// Freeze configuration, or `null` when streak freezes are disabled.
    /// </summary>
    [JsonPropertyName("freezes")]
    public StreakSettingsFreezes? Freezes { get; set; }

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
