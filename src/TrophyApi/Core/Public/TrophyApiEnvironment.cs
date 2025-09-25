namespace TrophyApi;

public class TrophyApiEnvironment
{
    public static readonly TrophyApiEnvironment Production = new TrophyApiEnvironment
    {
        Api = "https://api.trophy.so/v1",
        Admin = "https://admin.trophy.so/v1",
    };

    /// <summary>
    /// URL for the api service
    /// </summary>
    public string Api { get; init; }

    /// <summary>
    /// URL for the admin service
    /// </summary>
    public string Admin { get; init; }
}
