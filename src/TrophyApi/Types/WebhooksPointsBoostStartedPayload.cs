using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record WebhooksPointsBoostStartedPayload
{
    /// <summary>
    /// The webhook event type.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "points.boost_started";

    /// <summary>
    /// When the event occurred (ISO 8601).
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required DateTime Timestamp { get; set; }

    /// <summary>
    /// The points boost that started.
    /// </summary>
    [JsonPropertyName("boost")]
    public required PointsBoostWebhookPayload Boost { get; set; }

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
