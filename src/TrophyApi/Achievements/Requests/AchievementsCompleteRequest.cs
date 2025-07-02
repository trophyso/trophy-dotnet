using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record AchievementsCompleteRequest
{
    /// <summary>
    /// The user that completed the achievement.
    /// </summary>
    [JsonPropertyName("user")]
    public required UpdatedUser User { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
