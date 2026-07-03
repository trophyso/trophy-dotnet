using TrophyApi;

namespace TrophyApi.Admin.Points;

public partial interface IBoostsClient
{
    /// <summary>
    /// List points boosts for a system.
    /// </summary>
    WithRawResponseTask<IEnumerable<AdminPointsBoost>> ListAsync(
        string systemId,
        BoostsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create points boosts.
    /// </summary>
    WithRawResponseTask<CreatePointsBoostsResponse> CreateAsync(
        string systemId,
        IEnumerable<CreatePointsBoostRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete multiple points boosts by ID.
    /// </summary>
    WithRawResponseTask<DeletePointsBoostsResponse> DeleteAsync(
        string systemId,
        BoostsDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update multiple points boosts.
    /// </summary>
    WithRawResponseTask<PatchPointsBoostsResponse> UpdateAsync(
        string systemId,
        IEnumerable<PatchPointsBoostsRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single points boost by ID.
    /// </summary>
    WithRawResponseTask<AdminPointsBoost> GetAsync(
        string systemId,
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
