using TrophyApi.Admin;

namespace TrophyApi;

public partial interface ITrophyApiClient
{
    public IAchievementsClient Achievements { get; }
    public IMetricsClient Metrics { get; }
    public IUsersClient Users { get; }
    public IStreaksClient Streaks { get; }
    public IPointsClient Points { get; }
    public ILeaderboardsClient Leaderboards { get; }
    public IAdminClient Admin { get; }
}
