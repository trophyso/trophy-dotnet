using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Per-user streak configuration. Metric and evaluation mode overrides require streak customization to be enabled in dashboard settings.
/// </summary>
[Serializable]
public record StreakPreferences : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether streaks are calculated for this user. When false, the user's streak is always 0 and streak webhooks and notifications are not sent.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("evaluationMode")]
    public StreakEvaluationModePreference? EvaluationMode { get; set; }

    /// <summary>
    /// Metrics and thresholds that count toward this user's streak.
    /// </summary>
    [JsonPropertyName("metrics")]
    public IEnumerable<StreakMetricPreference>? Metrics { get; set; }

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
