using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A metric to create.
/// </summary>
[Serializable]
public record CreateMetricRequestItem
{
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
