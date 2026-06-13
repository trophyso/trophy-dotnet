using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Per-user streak configuration. Metric and evaluation mode overrides require streak customization to be enabled in dashboard settings.
/// </summary>
[Serializable]
public record StreakPreferences
{
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
