namespace TrophyApi;

[Serializable]
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
    public string Api { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }

    /// <summary>
    /// URL for the admin service
    /// </summary>
    public string Admin { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }
}
