namespace TrophyApi.Admin;

public partial interface IAdminClient
{
    public IAttributesClient Attributes { get; }
    public IMetricsClient Metrics { get; }
    public ILeaderboardsClient Leaderboards { get; }
    public IStreaksClient Streaks { get; }
    public IApplicationApiKeysClient ApplicationApiKeys { get; }
    public ITenantsClient Tenants { get; }
    public Points.IPointsClient Points { get; }
}
