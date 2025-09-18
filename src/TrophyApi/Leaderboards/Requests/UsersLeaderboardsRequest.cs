using TrophyApi.Core;

namespace TrophyApi;

public record UsersLeaderboardsRequest
{
    /// <summary>
    /// Specific run date in YYYY-MM-DD format. If not provided, returns the current run.
    /// </summary>
    public string? Run { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
