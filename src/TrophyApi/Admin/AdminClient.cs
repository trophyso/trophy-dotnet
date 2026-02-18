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
        Points = new PointsClient(_client);
    }

    public StreaksClient Streaks { get; }

    public PointsClient Points { get; }
}
