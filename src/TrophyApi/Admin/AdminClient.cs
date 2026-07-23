using TrophyApi.Core;

namespace TrophyApi.Admin;

public partial class AdminClient : IAdminClient
{
    private readonly RawClient _client;

    internal AdminClient(RawClient client)
    {
        _client = client;
        Attributes = new AttributesClient(_client);
        Metrics = new MetricsClient(_client);
        Leaderboards = new LeaderboardsClient(_client);
        Streaks = new StreaksClient(_client);
        ApplicationApiKeys = new ApplicationApiKeysClient(_client);
        Tenants = new TenantsClient(_client);
        Points = new TrophyApi.Admin.Points.PointsClient(_client);
    }

    public IAttributesClient Attributes { get; }

    public IMetricsClient Metrics { get; }

    public ILeaderboardsClient Leaderboards { get; }

    public IStreaksClient Streaks { get; }

    public IApplicationApiKeysClient ApplicationApiKeys { get; }

    public ITenantsClient Tenants { get; }

    public Points.IPointsClient Points { get; }
}
