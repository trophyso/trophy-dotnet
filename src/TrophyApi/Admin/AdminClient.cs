using TrophyApi.Core;

namespace TrophyApi.Admin;

public partial class AdminClient : IAdminClient
{
    private readonly RawClient _client;

    internal AdminClient(RawClient client)
    {
        _client = client;
        Attributes = new AttributesClient(_client);
        Achievements = new AchievementsClient(_client);
        Metrics = new MetricsClient(_client);
        Leaderboards = new LeaderboardsClient(_client);
        Streaks = new StreaksClient(_client);
        Settings = new SettingsClient(_client);
        ApplicationApiKeys = new ApplicationApiKeysClient(_client);
        Environments = new EnvironmentsClient(_client);
        Tenants = new TenantsClient(_client);
        Points = new TrophyApi.Admin.Points.PointsClient(_client);
    }

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
