using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A user's metric data for a wrapped period.
/// </summary>
[Serializable]
public record WrappedMetric : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the metric.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The units of the metric.
    /// </summary>
    [JsonPropertyName("units")]
    public string? Units { get; set; }

    /// <summary>
    /// The user's current total for the metric.
    /// </summary>
    [JsonPropertyName("currentTotal")]
    public required double CurrentTotal { get; set; }

    /// <summary>
    /// The change in the metric value during the period.
    /// </summary>
    [JsonPropertyName("changeThisPeriod")]
    public required double ChangeThisPeriod { get; set; }

    /// <summary>
    /// The percentage change in the metric value during the period.
    /// </summary>
    [JsonPropertyName("percentChange")]
    public required double PercentChange { get; set; }

    /// <summary>
    /// The user's percentile rank for this metric during the period. Only included for weekly, monthly, and yearly aggregation periods.
    /// </summary>
    [JsonPropertyName("percentileThisPeriod")]
    public double? PercentileThisPeriod { get; set; }

    /// <summary>
    /// Metric data broken down by attribute key and value.
    /// </summary>
    [JsonPropertyName("byAttribute")]
    public Dictionary<
        string,
        Dictionary<string, WrappedMetricByAttributeValueValue>
    > ByAttribute { get; set; } =
        new Dictionary<string, Dictionary<string, WrappedMetricByAttributeValueValue>>();

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
