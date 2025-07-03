using TrophyApi.Core;

namespace TrophyApi;

public record UsersPointsEventSummaryRequest
{
    /// <summary>
    /// The time period over which to aggregate the event data.
    /// </summary>
    public required UsersPointsEventSummaryRequestAggregation Aggregation { get; set; }

    /// <summary>
    /// The start date for the data range in YYYY-MM-DD format. The startDate must be before the endDate, and the date range must not exceed 400 days.
    /// </summary>
    public required string StartDate { get; set; }

    /// <summary>
    /// The end date for the data range in YYYY-MM-DD format. The endDate must be after the startDate, and the date range must not exceed 400 days.
    /// </summary>
    public required string EndDate { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
