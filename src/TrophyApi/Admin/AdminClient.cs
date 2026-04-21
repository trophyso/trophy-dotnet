using TrophyApi.Admin.Points;
using TrophyApi.Core;

namespace TrophyApi.Admin;

public partial class AdminClient
{
    private RawClient _client;

    internal AdminClient(RawClient client)
    {
        _client = client;
        Streaks = new StreaksClient(_client);
        Attributes = new AttributesClient(_client);
        Metrics = new MetricsClient(_client);
        Points = new PointsClient(_client);
    }

    public StreaksClient Streaks { get; }

    public AttributesClient Attributes { get; }

    public MetricsClient Metrics { get; }

    public PointsClient Points { get; }
}
