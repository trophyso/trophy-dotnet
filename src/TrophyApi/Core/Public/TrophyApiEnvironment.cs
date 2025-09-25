namespace TrophyApi;

public class TrophyApiEnvironment
{
    public static readonly TrophyApiEnvironment Production = new TrophyApiEnvironment
    {
        Api = "api.trophy.so",
        Admin = "admin.trophy.so",
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
