using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record LeaderboardsGetRequest
{
    /// <summary>
    /// Number of rankings to skip for pagination.
    /// </summary>
    [JsonIgnore]
    public int? Offset { get; set; }

    /// <summary>
    /// Maximum number of rankings to return.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Specific run date in YYYY-MM-DD format. If not provided, returns the current run.
    /// </summary>
    [JsonIgnore]
    public string? Run { get; set; }

    /// <summary>
    /// When provided, offset is relative to this user's position on the leaderboard. If the user is not found in the leaderboard, returns empty rankings array.
    /// </summary>
    [JsonIgnore]
    public string? UserId { get; set; }

    /// <summary>
    /// Attribute key and value to filter the rankings by, separated by a colon. This parameter is required, and only valid for leaderboards with a breakdown attribute.
    /// </summary>
    [JsonIgnore]
    public string? UserAttributes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
