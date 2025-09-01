using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record BulkStreakResponseItem
{
    /// <summary>
    /// The ID of the user.
    /// </summary>
    [JsonPropertyName("userId")]
    public required string UserId { get; set; }

    /// <summary>
    /// The length of the user's streak.
    /// </summary>
    [JsonPropertyName("streakLength")]
    public required int StreakLength { get; set; }

    /// <summary>
    /// The timestamp the streak was extended, as a string.
    /// </summary>
    [JsonPropertyName("extended")]
    public string? Extended { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
