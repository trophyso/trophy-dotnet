using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record AchievementResponse
{
    /// <summary>
    /// The unique ID of the achievement.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name of this achievement.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The URL of the badge image for the achievement, if one has been uploaded.
    /// </summary>
    [JsonPropertyName("badgeUrl")]
    public string? BadgeUrl { get; set; }

    /// <summary>
    /// The ID of the metric associated with this achievement, if any.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// The value of the metric required to complete the achievement, if this achievement is associated with a metric.
    /// </summary>
    [JsonPropertyName("metricValue")]
    public double? MetricValue { get; set; }

    /// <summary>
    /// The name of the metric associated with this achievement, if any.
    /// </summary>
    [JsonPropertyName("metricName")]
    public string? MetricName { get; set; }

    /// <summary>
    /// The key used to reference this achievement in the API.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// The date and time the achievement was completed, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("achievedAt")]
    public DateTime? AchievedAt { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
