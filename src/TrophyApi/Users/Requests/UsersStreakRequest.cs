using TrophyApi.Core;

namespace TrophyApi;

public record UsersStreakRequest
{
    /// <summary>
    /// The number of past streak periods to include in the streakHistory field of the  response.
    /// </summary>
    public int? HistoryPeriods { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
