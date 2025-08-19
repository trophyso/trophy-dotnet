using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record AchievementCompletionResponse
{
    /// <summary>
    /// The unique ID of the completion.
    /// </summary>
    [JsonPropertyName("completionId")]
    public required string CompletionId { get; set; }

    [JsonPropertyName("achievement")]
    public required CompletedAchievementResponse Achievement { get; set; }

    /// <summary>
    /// A map of points systems by key that were affected by this achievement completion.
    /// </summary>
    [JsonPropertyName("points")]
    public Dictionary<string, MetricEventPointsResponse>? Points { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
