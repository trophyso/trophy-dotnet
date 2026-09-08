using TrophyApi;

namespace TrophyApi.Admin;

public partial interface IAchievementsClient
{
    /// <summary>
    /// List achievements.
    /// </summary>
    WithRawResponseTask<IEnumerable<AdminAchievement>> ListAsync(
        AchievementsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create achievements. Trigger-specific fields are required based on `trigger`.
    /// </summary>
    WithRawResponseTask<CreateAchievementsResponse> CreateAsync(
        IEnumerable<CreateAchievementRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete achievements by ID.
    /// </summary>
    WithRawResponseTask<DeleteAchievementsResponse> DeleteAsync(
        AchievementsDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update achievements by ID. Maximum 100 achievements per request. Only provided fields are updated; omitted fields are preserved.
    /// </summary>
    WithRawResponseTask<UpdateAchievementsResponse> UpdateAsync(
        IEnumerable<UpdateAchievementRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get an achievement by ID.
    /// </summary>
    WithRawResponseTask<AdminAchievement> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
