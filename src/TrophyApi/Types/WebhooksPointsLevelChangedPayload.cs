using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record WebhooksPointsLevelChangedPayload
{
    /// <summary>
    /// The webhook event type.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "points.level_changed";

    /// <summary>
    /// The user whose level changed.
    /// </summary>
    [JsonPropertyName("user")]
    public required User User { get; set; }

    /// <summary>
    /// The points system in which the level changed.
    /// </summary>
    [JsonPropertyName("points")]
    public required WebhooksPointsLevelChangedPayloadPoints Points { get; set; }

    /// <summary>
    /// The user's previous level, or null if the user had no level.
    /// </summary>
    [JsonPropertyName("previousLevel")]
    public PointsLevel? PreviousLevel { get; set; }

    /// <summary>
    /// The user's new level, or null if the user no longer has a level.
    /// </summary>
    [JsonPropertyName("newLevel")]
    public PointsLevel? NewLevel { get; set; }

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
