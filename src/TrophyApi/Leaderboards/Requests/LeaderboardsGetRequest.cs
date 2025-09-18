using TrophyApi.Core;

namespace TrophyApi;

public record LeaderboardsGetRequest
{
    /// <summary>
    /// Number of rankings to skip for pagination.
    /// </summary>
    public int? Offset { get; set; }

    /// <summary>
    /// Maximum number of rankings to return.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Specific run date in YYYY-MM-DD format. If not provided, returns the current run.
    /// </summary>
    public string? Run { get; set; }

    /// <summary>
    /// When provided, offset is relative to this user's position on the leaderboard. If the user is not found in the leaderboard, returns empty rankings array.
    /// </summary>
    public string? UserId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
