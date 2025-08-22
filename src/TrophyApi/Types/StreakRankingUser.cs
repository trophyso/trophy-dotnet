using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record StreakRankingUser
{
    /// <summary>
    /// The ID of the user.
    /// </summary>
    [JsonPropertyName("userId")]
    public required string UserId { get; set; }

    /// <summary>
    /// The name of the user. May be null if no name is set.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The user's streak length (active or longest depending on query parameter).
    /// </summary>
    [JsonPropertyName("streakLength")]
    public required int StreakLength { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
