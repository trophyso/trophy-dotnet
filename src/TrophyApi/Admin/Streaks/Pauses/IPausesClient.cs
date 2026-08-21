using TrophyApi;

namespace TrophyApi.Admin.Streaks;

public partial interface IPausesClient
{
    /// <summary>
    /// Create streak pauses for multiple users. A pause covers a specific date range and maintains the user's streak length during that range instead of ending the streak. Start dates in the past are rejected.
    /// </summary>
    WithRawResponseTask<CreateStreakPausesResponse> CreateAsync(
        CreateStreakPausesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive streak pauses by ID. Pause records are not deleted; their status is set to archived so they no longer apply to streak logic.
    /// </summary>
    WithRawResponseTask<DeleteStreakPausesResponse> DeleteAsync(
        PausesDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
