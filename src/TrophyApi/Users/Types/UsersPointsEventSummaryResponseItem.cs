using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record UsersPointsEventSummaryResponseItem
{
    /// <summary>
    /// The date of the data point. For weekly or monthly aggregations, this is the first date of the period.
    /// </summary>
    [JsonPropertyName("date")]
    public required string Date { get; set; }

    /// <summary>
    /// The user's total points at the end of this date.
    /// </summary>
    [JsonPropertyName("total")]
    public required double Total { get; set; }

    /// <summary>
    /// The change in the user's total points during this period.
    /// </summary>
    [JsonPropertyName("change")]
    public required double Change { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
