using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record AchievementWithStatsResponse
{
    /// <summary>
    /// The number of users who have completed this achievement.
    /// </summary>
    [JsonPropertyName("completions")]
    public int? Completions { get; set; }

    /// <summary>
    /// The percentage of all users who have completed this achievement.
    /// </summary>
    [JsonPropertyName("completedPercentage")]
    public double? CompletedPercentage { get; set; }

    /// <summary>
    /// The unique ID of the achievement.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name of this achievement.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The trigger of the achievement, either 'metric', 'streak', or 'api'.
    /// </summary>
    [JsonPropertyName("trigger")]
    public required string Trigger { get; set; }

    /// <summary>
    /// The description of this achievement.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The URL of the badge image for the achievement, if one has been uploaded.
    /// </summary>
    [JsonPropertyName("badgeUrl")]
    public string? BadgeUrl { get; set; }

    /// <summary>
    /// The key used to reference this achievement in the API (only applicable if trigger = 'api')
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// The length of the streak required to complete the achievement (only applicable if trigger = 'streak')
    /// </summary>
    [JsonPropertyName("streakLength")]
    public int? StreakLength { get; set; }

    /// <summary>
    /// The ID of the metric associated with this achievement (only applicable if trigger = 'metric')
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// The value of the metric required to complete the achievement (only applicable if trigger = 'metric')
    /// </summary>
    [JsonPropertyName("metricValue")]
    public double? MetricValue { get; set; }

    /// <summary>
    /// The name of the metric associated with this achievement (only applicable if trigger = 'metric')
    /// </summary>
    [JsonPropertyName("metricName")]
    public string? MetricName { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
