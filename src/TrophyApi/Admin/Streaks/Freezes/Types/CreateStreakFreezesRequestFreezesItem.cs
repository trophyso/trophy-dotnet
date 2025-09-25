using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin.Streaks;

public record CreateStreakFreezesRequestFreezesItem
{
    /// <summary>
    /// The ID of the user to create a freeze for.
    /// </summary>
    [JsonPropertyName("userId")]
    public required string UserId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
