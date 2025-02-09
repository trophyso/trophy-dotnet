using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record EventResponseMetricsItem
{
    /// <summary>
    /// The ID of the metric.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// A list of any new achievements that the user has now completed as a result of this event being submitted.
    /// </summary>
    [JsonPropertyName("completed")]
    public IEnumerable<AchievementResponse>? Completed { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
