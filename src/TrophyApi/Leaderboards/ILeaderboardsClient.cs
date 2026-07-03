namespace TrophyApi;

public partial interface ILeaderboardsClient
{
    /// <summary>
    /// Get all leaderboards for your organization. Finished leaderboards are excluded by default.
    /// </summary>
    WithRawResponseTask<IEnumerable<LeaderboardsAllResponseItem>> AllAsync(
        LeaderboardsAllRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a specific leaderboard by its key.
    /// </summary>
    WithRawResponseTask<LeaderboardResponseWithRankings> GetAsync(
        string key,
        LeaderboardsGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
