namespace TrophyApi.Admin;

public partial interface IAdminClient
{
    public IAttributesClient Attributes { get; }
    public IAchievementsClient Achievements { get; }
    public IMetricsClient Metrics { get; }
    public ILeaderboardsClient Leaderboards { get; }
    public IStreaksClient Streaks { get; }
    public ISettingsClient Settings { get; }
    public IApplicationApiKeysClient ApplicationApiKeys { get; }
    public IEnvironmentsClient Environments { get; }
    public ITenantsClient Tenants { get; }
    public Points.IPointsClient Points { get; }
}
