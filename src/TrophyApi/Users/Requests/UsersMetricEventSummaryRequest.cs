using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record UsersMetricEventSummaryRequest
{
    /// <summary>
    /// The time period over which to aggregate the event data.
    /// </summary>
    [JsonIgnore]
    public required UsersMetricEventSummaryRequestAggregation Aggregation { get; set; }

    /// <summary>
    /// The start date for the data range in YYYY-MM-DD format. The startDate must be before the endDate, and the date range must not exceed 400 days.
    /// </summary>
    [JsonIgnore]
    public required string StartDate { get; set; }

    /// <summary>
    /// The end date for the data range in YYYY-MM-DD format. The endDate must be after the startDate, and the date range must not exceed 400 days.
    /// </summary>
    [JsonIgnore]
    public required string EndDate { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
