using TrophyApi.Core;

namespace TrophyApi;

public partial class TrophyApiClient
{
    private readonly RawClient _client;

    public TrophyApiClient(string? apiKey = null, ClientOptions? clientOptions = null)
    {
        var defaultHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-API-KEY", apiKey },
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "TrophyApi" },
                { "X-Fern-SDK-Version", Version.Current },
            }
        );
        clientOptions ??= new ClientOptions();
        foreach (var header in defaultHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        _client = new RawClient(clientOptions);
        Achievements = new AchievementsClient(_client);
        Metrics = new MetricsClient(_client);
        Users = new UsersClient(_client);
    }

    public AchievementsClient Achievements { get; init; }

    public MetricsClient Metrics { get; init; }

    public UsersClient Users { get; init; }
}
