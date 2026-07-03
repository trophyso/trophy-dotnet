using TrophyApi;

namespace TrophyApi.Admin;

public partial interface IMetricsClient
{
    /// <summary>
    /// List metrics.
    /// </summary>
    WithRawResponseTask<IEnumerable<CreatedMetric>> ListAsync(
        MetricsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create metrics.
    /// </summary>
    WithRawResponseTask<CreateMetricsResponse> CreateAsync(
        IEnumerable<CreateMetricRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete metrics by ID.
    /// </summary>
    WithRawResponseTask<DeleteMetricsResponse> DeleteAsync(
        MetricsDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update metrics by ID.
    /// </summary>
    WithRawResponseTask<UpdateMetricsResponse> UpdateAsync(
        IEnumerable<UpdateMetricRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a metric by ID.
    /// </summary>
    WithRawResponseTask<CreatedMetric> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
