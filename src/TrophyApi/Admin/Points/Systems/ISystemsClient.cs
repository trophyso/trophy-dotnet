using TrophyApi;

namespace TrophyApi.Admin.Points;

public partial interface ISystemsClient
{
    /// <summary>
    /// List points systems.
    /// </summary>
    WithRawResponseTask<IEnumerable<AdminPointsSystem>> ListAsync(
        SystemsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create points systems. Optionally include sub-entities (levels, boosts, triggers) in each system payload to create them alongside the system.
    /// </summary>
    WithRawResponseTask<CreatePointsSystemsResponse> CreateAsync(
        IEnumerable<CreatePointsSystemRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete (archive) points systems by ID.
    /// </summary>
    WithRawResponseTask<DeletePointsSystemsResponse> DeleteAsync(
        SystemsDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update points systems by ID.
    /// </summary>
    WithRawResponseTask<UpdatePointsSystemsResponse> UpdateAsync(
        IEnumerable<UpdatePointsSystemRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a points system by ID.
    /// </summary>
    WithRawResponseTask<AdminPointsSystem> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
