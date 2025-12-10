using TrophyApi.Core;

namespace TrophyApi.Admin;

public partial class AdminClient
{
    private RawClient _client;

    internal AdminClient(RawClient client)
    {
        _client = client;
        Streaks = new StreaksClient(_client);
    }

    public StreaksClient Streaks { get; }
}
