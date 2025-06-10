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
    public required ApiAchievementResponse Achievement { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
