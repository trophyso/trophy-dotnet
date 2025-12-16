using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record AchievementCompletionResponse
{
    /// <summary>
    /// The unique ID of the completion.
    /// </summary>
    [JsonPropertyName("completionId")]
    public required string CompletionId { get; set; }

    [JsonPropertyName("achievement")]
    public required UserAchievementResponse Achievement { get; set; }

    /// <summary>
    /// A map of points systems by key that were affected by this achievement completion.
    /// </summary>
    [JsonPropertyName("points")]
    public Dictionary<string, MetricEventPointsResponse> Points { get; set; } =
        new Dictionary<string, MetricEventPointsResponse>();

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
