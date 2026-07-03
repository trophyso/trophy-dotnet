using TrophyApi;

namespace TrophyApi.Admin.Points;

public partial interface ILevelsClient
{
    /// <summary>
    /// List points levels for a system.
    /// </summary>
    WithRawResponseTask<IEnumerable<AdminPointsLevel>> ListAsync(
        string systemId,
        LevelsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create points levels. Maximum 100 levels per request.
    /// </summary>
    WithRawResponseTask<CreatePointsLevelsResponse> CreateAsync(
        string systemId,
        IEnumerable<CreatePointsLevelRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete multiple points levels by ID.
    /// </summary>
    WithRawResponseTask<DeletePointsLevelsResponse> DeleteAsync(
        string systemId,
        LevelsDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update multiple points levels. Each item must include an ID. `key` cannot be changed.
    /// </summary>
    WithRawResponseTask<PatchPointsLevelsResponse> UpdateAsync(
        string systemId,
        IEnumerable<PatchPointsLevelsRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single points level by ID.
    /// </summary>
    WithRawResponseTask<AdminPointsLevel> GetAsync(
        string systemId,
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
