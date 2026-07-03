namespace TrophyApi;

public partial interface IStreaksClient
{
    /// <summary>
    /// Get the streak lengths of a list of users, ranked by streak length from longest to shortest.
    /// </summary>
    WithRawResponseTask<IEnumerable<BulkStreakResponseItem>> ListAsync(
        StreaksListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
