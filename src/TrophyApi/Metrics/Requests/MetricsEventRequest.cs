using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record MetricsEventRequest
{
    /// <summary>
    /// The idempotency key for the event.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The user that triggered the event.
    /// </summary>
    [JsonPropertyName("user")]
    public required UpsertedUser User { get; set; }

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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
