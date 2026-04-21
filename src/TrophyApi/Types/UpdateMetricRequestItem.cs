using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A metric update object. `id` is required; `name`, `unitType`, and `units` are optional. `key` cannot be changed through this endpoint.
/// </summary>
[Serializable]
public record UpdateMetricRequestItem
{
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
