using global::System.Text.Json.Serialization;
using TrophyApi;
using TrophyApi.Core;

namespace TrophyApi.Admin.Streaks;

[Serializable]
public record UpdateStreakSettingsRequest
{
    [JsonPropertyName("frequency")]
    public AdminStreakFrequency? Frequency { get; set; }

    [JsonPropertyName("evaluationMode")]
    public AdminStreakEvaluationMode? EvaluationMode { get; set; }

    /// <summary>
    /// Whether users can override streak evaluation mode, metric thresholds, and days off via preferences.
    /// </summary>
    [JsonPropertyName("customizationEnabled")]
    public bool? CustomizationEnabled { get; set; }

    /// <summary>
    /// Days of the week that do not count toward the daily streak. A non-empty array is only allowed when the resulting frequency is `daily`. Changing frequency away from `daily` clears stored days off even when this field is omitted.
    /// </summary>
    [JsonPropertyName("daysOff")]
    public IEnumerable<int>? DaysOff { get; set; }

    /// <summary>
    /// Replacement list of streak metrics. Keys must be unique and must exist on the organization.
    /// </summary>
    [JsonPropertyName("metrics")]
    public IEnumerable<StreakSettingsMetric>? Metrics { get; set; }

    /// <summary>
    /// Replacement freeze configuration, or `null` to disable freezes.
    /// </summary>
    [JsonPropertyName("freezes")]
    public UpdateStreakSettingsFreezes? Freezes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
