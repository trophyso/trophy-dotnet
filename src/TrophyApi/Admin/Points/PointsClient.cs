using TrophyApi.Core;

namespace TrophyApi.Admin.Points;

public partial class PointsClient
{
    private RawClient _client;

    internal PointsClient(RawClient client)
    {
        _client = client;
        Systems = new SystemsClient(_client);
        Boosts = new BoostsClient(_client);
        Levels = new LevelsClient(_client);
        Triggers = new TriggersClient(_client);
    }

    public SystemsClient Systems { get; }

    public BoostsClient Boosts { get; }

    public LevelsClient Levels { get; }

    public TriggersClient Triggers { get; }
}
