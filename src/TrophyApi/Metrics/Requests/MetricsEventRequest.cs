using TrophyApi.Core;

namespace TrophyApi;

public record MetricsEventRequest
{
    /// <summary>
    /// The idempotency key for the event.
    /// </summary>
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The user that triggered the event.
    /// </summary>
    public required UpsertedUser User { get; set; }

    /// <summary>
    /// The value to add to the user's current total for the given metric.
    /// </summary>
    public required double Value { get; set; }

    /// <summary>
    /// Event attributes as key-value pairs. Keys must match existing event attributes set up in the Trophy dashboard.
    /// </summary>
    public Dictionary<string, string>? Attributes { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
