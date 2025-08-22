using TrophyApi.Core;

namespace TrophyApi;

public record StreaksRankingsRequest
{
    /// <summary>
    /// Number of users to return. Must be between 1 and 100.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Whether to rank users by active streaks or longest streaks ever achieved.
    /// </summary>
    public StreaksRankingsRequestType? Type { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
