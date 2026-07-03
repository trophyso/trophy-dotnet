using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A metric update object. `id` is required; `name`, `unitType`, and `units` are optional. `key` cannot be changed through this endpoint.
/// </summary>
[Serializable]
public record UpdateMetricRequestItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the metric to update.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The updated metric name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The updated metric unit type.
    /// </summary>
    [JsonPropertyName("unitType")]
    public UpdateMetricRequestItemUnitType? UnitType { get; set; }

    /// <summary>
    /// The updated units value. For `unitType: currency`, this must be a supported `MetricCurrency` code such as `USD`.
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
