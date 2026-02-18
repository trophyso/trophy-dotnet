using TrophyApi.Core;

namespace TrophyApi.Admin.Points;

public partial class PointsClient
{
    private RawClient _client;

    internal PointsClient(RawClient client)
    {
        _client = client;
        Boosts = new BoostsClient(_client);
    }

    public BoostsClient Boosts { get; }
}
