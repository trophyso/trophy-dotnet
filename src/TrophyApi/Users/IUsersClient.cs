namespace TrophyApi;

public partial interface IUsersClient
{
    /// <summary>
    /// Create a new user.
    /// </summary>
    WithRawResponseTask<User> CreateAsync(
        UpsertedUser request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single user.
    /// </summary>
    WithRawResponseTask<User> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Identify a user.
    /// </summary>
    WithRawResponseTask<User> IdentifyAsync(
        string id,
        UpdatedUser request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a user.
    /// </summary>
    WithRawResponseTask<User> UpdateAsync(
        string id,
        UpdatedUser request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a user's notification preferences.
    /// </summary>
    WithRawResponseTask<UserPreferencesResponse> GetPreferencesAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a user's notification and streak preferences. Streak preferences require streak customization to be enabled in your Trophy dashboard settings.
    /// </summary>
    WithRawResponseTask<UserPreferencesResponse> UpdatePreferencesAsync(
        string id,
        UpdateUserPreferencesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single user's progress against all active metrics.
    /// </summary>
    WithRawResponseTask<IEnumerable<MetricResponse>> AllMetricsAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a user's progress against a single active metric.
    /// </summary>
    WithRawResponseTask<MetricResponse> SingleMetricAsync(
        string id,
        string key,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a summary of metric events over time for a user.
    /// </summary>
    WithRawResponseTask<IEnumerable<UsersMetricEventSummaryResponseItem>> MetricEventSummaryAsync(
        string id,
        string key,
        UsersMetricEventSummaryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a user's achievements.
    /// </summary>
    WithRawResponseTask<IEnumerable<UserAchievementWithStatsResponse>> AchievementsAsync(
        string id,
        UsersAchievementsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a user's streak data.
    /// </summary>
    WithRawResponseTask<StreakResponse> StreakAsync(
        string id,
        UsersStreakRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a user's points for a specific points system.
    /// </summary>
    WithRawResponseTask<GetUserPointsResponse> PointsAsync(
        string id,
        string key,
        UsersPointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get active points boosts for a user in a specific points system. Returns both global boosts the user is eligible for and user-specific boosts.
    /// </summary>
    WithRawResponseTask<IEnumerable<PointsBoost>> PointsBoostsAsync(
        string id,
        string key,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a summary of points awards over time for a user for a specific points system.
    /// </summary>
    WithRawResponseTask<IEnumerable<UsersPointsEventSummaryResponseItem>> PointsEventSummaryAsync(
        string id,
        string key,
        UsersPointsEventSummaryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a user's rank, value, and daily ranking history for a specific leaderboard.
    /// </summary>
    WithRawResponseTask<UserLeaderboardResponseWithHistory> LeaderboardAsync(
        string id,
        string key,
        UsersLeaderboardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a user's year-in-review wrapped data.
    /// </summary>
    WithRawResponseTask<WrappedResponse> WrappedAsync(
        string id,
        UsersWrappedRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
