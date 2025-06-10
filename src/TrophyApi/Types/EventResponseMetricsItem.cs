using System.Text.Json.Serialization;
using OneOf;
using TrophyApi.Core;

namespace TrophyApi;

public record EventResponseMetricsItem
{
    /// <summary>
    /// The trigger of the achievement, in this case either 'metric' or 'streak'.
    /// </summary>
    [JsonPropertyName("trigger")]
    public string? Trigger { get; set; }

    /// <summary>
    /// The ID of the metric that these achievements are associated with, if any.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// A list of any new achievements that the user has now completed as a result of this event being submitted.
    /// </summary>
    [JsonPropertyName("completed")]
    public IEnumerable<
        OneOf<MetricAchievementResponse, StreakAchievementResponse>
    > Completed { get; set; } =
        new List<OneOf<MetricAchievementResponse, StreakAchievementResponse>>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
