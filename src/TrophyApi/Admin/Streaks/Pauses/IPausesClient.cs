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
    /// Delete streak pauses by ID.
    /// </summary>
    WithRawResponseTask<DeleteStreakPausesResponse> DeleteAsync(
        PausesDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
