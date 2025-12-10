using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A user's metric data for a wrapped period.
/// </summary>
[Serializable]
public record WrappedMetric
{
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
