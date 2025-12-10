using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record WrappedMetricByAttributeValueValue
{
    /// <summary>
    /// The name of the metric.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The units of the metric.
    /// </summary>
    [JsonPropertyName("units")]
    public string? Units { get; set; }

    /// <summary>
    /// The current total for this attribute value.
    /// </summary>
    [JsonPropertyName("currentTotal")]
    public double? CurrentTotal { get; set; }

    /// <summary>
    /// The change during the period for this attribute value.
    /// </summary>
    [JsonPropertyName("changeThisPeriod")]
    public double? ChangeThisPeriod { get; set; }

    /// <summary>
    /// The percentage change for this attribute value.
    /// </summary>
    [JsonPropertyName("percentChange")]
    public double? PercentChange { get; set; }

    /// <summary>
    /// The user's percentile rank for this attribute value during the period.
    /// </summary>
    [JsonPropertyName("percentileThisPeriod")]
    public double? PercentileThisPeriod { get; set; }

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
