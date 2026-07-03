namespace TrophyApi;

public partial interface IMetricsClient
{
    /// <summary>
    /// Increment or decrement the value of a metric for a user.
    /// </summary>
    WithRawResponseTask<EventResponse> EventAsync(
        string key,
        MetricsEventRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
