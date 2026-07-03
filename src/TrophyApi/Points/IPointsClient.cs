namespace TrophyApi;

public partial interface IPointsClient
{
    /// <summary>
    /// Get a breakdown of the number of users with points in each range.
    /// </summary>
    WithRawResponseTask<IEnumerable<PointsRange>> SummaryAsync(
        string key,
        PointsSummaryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a points system with its triggers.
    /// </summary>
    WithRawResponseTask<PointsSystemResponse> SystemAsync(
        string key,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get all global boosts for a points system. Finished boosts are excluded by default.
    /// </summary>
    WithRawResponseTask<IEnumerable<PointsBoost>> BoostsAsync(
        string key,
        PointsBoostsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get all levels for a points system.
    /// </summary>
    WithRawResponseTask<IEnumerable<PointsLevel>> LevelsAsync(
        string key,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a breakdown of the number of users at each level in a points system.
    /// </summary>
    WithRawResponseTask<IEnumerable<PointsLevelSummaryResponseItem>> LevelSummaryAsync(
        string key,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
