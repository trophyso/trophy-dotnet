using TrophyApi.Core;

namespace TrophyApi.Admin.Streaks;

public partial class StreaksClient
{
    private RawClient _client;

    internal StreaksClient(RawClient client)
    {
        _client = client;
        Freezes = new FreezesClient(_client);
    }

    public FreezesClient Freezes { get; }
}
