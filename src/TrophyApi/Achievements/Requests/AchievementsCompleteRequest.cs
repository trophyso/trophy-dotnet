using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record AchievementsCompleteRequest
{
    /// <summary>
    /// The user that completed the achievement.
    /// </summary>
    [JsonPropertyName("user")]
    public required UpsertedUser User { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
