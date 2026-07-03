using TrophyApi;

namespace TrophyApi.Admin.Streaks;

public partial interface IFreezesClient
{
    /// <summary>
    /// Create streak freezes for multiple users.
    /// </summary>
    WithRawResponseTask<CreateStreakFreezesResponse> CreateAsync(
        CreateStreakFreezesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
