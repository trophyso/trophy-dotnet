using TrophyApi.Core;

namespace TrophyApi.Admin.Points;

public partial class PointsClient : IPointsClient
{
    private readonly RawClient _client;

    internal PointsClient(RawClient client)
    {
        _client = client;
        Systems = new SystemsClient(_client);
        Boosts = new BoostsClient(_client);
        Levels = new LevelsClient(_client);
        Triggers = new TriggersClient(_client);
    }

    public ISystemsClient Systems { get; }

    public IBoostsClient Boosts { get; }

    public ILevelsClient Levels { get; }

    public ITriggersClient Triggers { get; }
}
