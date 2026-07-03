using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A metric to create.
/// </summary>
[Serializable]
public record CreateMetricRequestItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The metric name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The metric key. Only alphanumeric characters, hyphens, and underscores are permitted.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// The metric unit type. Defaults to `number`.
    /// </summary>
    [JsonPropertyName("unitType")]
    public CreateMetricRequestItemUnitType? UnitType { get; set; }

    /// <summary>
    /// For `unitType: currency`, this must be a supported `MetricCurrency` code such as `USD`. For `number`, this is an optional freeform unit label.
    /// </summary>
    [JsonPropertyName("units")]
    public string? Units { get; set; }

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
