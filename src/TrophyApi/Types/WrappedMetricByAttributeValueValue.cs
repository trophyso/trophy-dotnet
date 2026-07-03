using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record WrappedMetricByAttributeValueValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
