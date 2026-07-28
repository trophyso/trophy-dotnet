using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A metric event submitted as part of a batch. Same shape as a single metric event, with the metric key included in the body.
/// </summary>
[Serializable]
public record BatchMetricEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique reference of the metric as set when created.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// The user that triggered the event.
    /// </summary>
    [JsonPropertyName("user")]
    public required BatchMetricEventUser User { get; set; }

    /// <summary>
    /// The value to add to the user's current total for the given metric.
    /// </summary>
    [JsonPropertyName("value")]
    public required double Value { get; set; }

    /// <summary>
    /// Event attributes as key-value pairs. Keys must match existing event attributes set up in the Trophy dashboard.
    /// </summary>
    [JsonPropertyName("attributes")]
    public Dictionary<string, string>? Attributes { get; set; }

    /// <summary>
    /// Optional idempotency key for this event. When provided, the event is ignored if another event with the same idempotency key has already  been processed.
    /// </summary>
    [JsonPropertyName("idempotencyKey")]
    public string? IdempotencyKey { get; set; }

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
