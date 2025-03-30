using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record MetricsEventRequest
{
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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
