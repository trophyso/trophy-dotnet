using TrophyApi;

namespace TrophyApi.Admin;

public partial interface ILeaderboardsClient
{
    /// <summary>
    /// List leaderboards.
    /// </summary>
    WithRawResponseTask<IEnumerable<AdminLeaderboard>> ListAsync(
        LeaderboardsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create leaderboards. Maximum 100 leaderboards per request.
    /// </summary>
    WithRawResponseTask<CreateLeaderboardsResponse> CreateAsync(
        IEnumerable<CreateLeaderboardRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete leaderboards by ID.
    /// </summary>
    WithRawResponseTask<DeleteLeaderboardsResponse> DeleteAsync(
        LeaderboardsDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update leaderboards by ID. Updating `status` behaves the same as activating, scheduling, deactivating, or finishing a leaderboard in the dashboard.
    /// </summary>
    WithRawResponseTask<UpdateLeaderboardsResponse> UpdateAsync(
        IEnumerable<UpdateLeaderboardRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a leaderboard by ID.
    /// </summary>
    WithRawResponseTask<AdminLeaderboard> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
