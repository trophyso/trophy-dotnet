namespace TrophyApi;

public partial interface IAchievementsClient
{
    /// <summary>
    /// Get all achievements and their completion stats.
    /// </summary>
    WithRawResponseTask<IEnumerable<AchievementWithStatsResponse>> AllAsync(
        AchievementsAllRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Mark an achievement as completed for a user.
    /// </summary>
    WithRawResponseTask<AchievementCompletionResponse> CompleteAsync(
        string key,
        AchievementsCompleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
