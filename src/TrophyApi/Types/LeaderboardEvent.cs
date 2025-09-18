using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record LeaderboardEvent
{
    /// <summary>
    /// The timestamp when the event occurred.
    /// </summary>
    [JsonPropertyName("time")]
    public required DateTime Time { get; set; }

    /// <summary>
    /// The user's rank before this event, or null if they were not on the leaderboard.
    /// </summary>
    [JsonPropertyName("previousRank")]
    public int? PreviousRank { get; set; }

    /// <summary>
    /// The user's rank after this event, or null if they are no longer on the leaderboard.
    /// </summary>
    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

    /// <summary>
    /// The user's value before this event, or null if they were not on the leaderboard.
    /// </summary>
    [JsonPropertyName("previousValue")]
    public int? PreviousValue { get; set; }

    /// <summary>
    /// The user's value after this event, or null if they are no longer on the leaderboard.
    /// </summary>
    [JsonPropertyName("value")]
    public int? Value { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
