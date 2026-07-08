using TrophyApi.Admin;
using TrophyApi.Core;

namespace TrophyApi;

public partial class TrophyApiClient : ITrophyApiClient
{
    private readonly RawClient _client;

    public TrophyApiClient(
        string? apiKey = null,
        string? sdkVersion = null,
        string? tenantId = null,
        ClientOptions? clientOptions = null
    )
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "TrophyApi" },
                { "X-Fern-SDK-Version", Version.Current },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-API-KEY", apiKey ?? "" },
                { "X-SDK-VERSION", sdkVersion ?? "1.16.0" },
                { "Tenant-ID", tenantId ?? "" },
            }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        Achievements = new AchievementsClient(_client);
        Metrics = new MetricsClient(_client);
        Users = new UsersClient(_client);
        Streaks = new StreaksClient(_client);
        Points = new PointsClient(_client);
        Leaderboards = new LeaderboardsClient(_client);
        Admin = new AdminClient(_client);
    }

    public IAchievementsClient Achievements { get; }

    public IMetricsClient Metrics { get; }

    public IUsersClient Users { get; }

    public IStreaksClient Streaks { get; }

    public IPointsClient Points { get; }

    public ILeaderboardsClient Leaderboards { get; }

    public IAdminClient Admin { get; }
}
