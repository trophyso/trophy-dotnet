using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record WebhooksAchievementCompletedPayload
{
    /// <summary>
    /// The webhook event type.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "achievement.completed";

    /// <summary>
    /// The user who completed the achievement.
    /// </summary>
    [JsonPropertyName("user")]
    public required User User { get; set; }

    /// <summary>
    /// The achievement completion that occurred.
    /// </summary>
    [JsonPropertyName("achievement")]
    public required UserAchievementResponse Achievement { get; set; }

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
