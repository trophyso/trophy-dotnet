using TrophyApi.Admin.Points;
using TrophyApi.Core;

namespace TrophyApi.Admin;

public partial class AdminClient
{
    private RawClient _client;

    internal AdminClient(RawClient client)
    {
        _client = client;
        Attributes = new AttributesClient(_client);
        Metrics = new MetricsClient(_client);
        Leaderboards = new LeaderboardsClient(_client);
        Streaks = new StreaksClient(_client);
        Points = new PointsClient(_client);
    }

    public AttributesClient Attributes { get; }

    public MetricsClient Metrics { get; }

    public LeaderboardsClient Leaderboards { get; }

    public StreaksClient Streaks { get; }

    public PointsClient Points { get; }
}
