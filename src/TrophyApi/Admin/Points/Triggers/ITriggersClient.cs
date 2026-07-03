using TrophyApi;

namespace TrophyApi.Admin.Points;

public partial interface ITriggersClient
{
    /// <summary>
    /// List points triggers for a system.
    /// </summary>
    WithRawResponseTask<IEnumerable<AdminPointsTrigger>> ListAsync(
        string systemId,
        TriggersListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create points triggers in bulk. Maximum 100 triggers per request.
    /// </summary>
    WithRawResponseTask<CreatePointsTriggersResponse> CreateAsync(
        string systemId,
        IEnumerable<CreatePointsTriggerRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete (archive) points triggers by ID. Maximum 100 trigger IDs per request.
    /// </summary>
    WithRawResponseTask<DeletePointsTriggersResponse> DeleteAsync(
        string systemId,
        TriggersDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update points triggers in bulk. Maximum 100 triggers per request. Only provided fields are updated; omitted fields are preserved.
    /// </summary>
    WithRawResponseTask<PatchPointsTriggersResponse> UpdateAsync(
        string systemId,
        IEnumerable<PatchPointsTriggersRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single points trigger by ID.
    /// </summary>
    WithRawResponseTask<AdminPointsTrigger> GetAsync(
        string systemId,
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
