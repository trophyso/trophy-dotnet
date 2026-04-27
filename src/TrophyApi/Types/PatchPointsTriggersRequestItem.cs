using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record PatchPointsTriggersRequestItem
{
    /// <summary>
    /// The UUID of the trigger to update.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Updated trigger type. Can only be changed when the trigger is inactive. Required fields for the new type must be provided.
    /// </summary>
    [JsonPropertyName("type")]
    public PatchPointsTriggersRequestItemType? Type { get; set; }

    /// <summary>
    /// Updated points value.
    /// </summary>
    [JsonPropertyName("points")]
    public int? Points { get; set; }

    /// <summary>
    /// Updated status.
    /// </summary>
    [JsonPropertyName("status")]
    public PatchPointsTriggersRequestItemStatus? Status { get; set; }

    /// <summary>
    /// Updated user attribute filters. Set to null to clear.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<PatchPointsTriggersRequestItemUserAttributesItem>? UserAttributes { get; set; }

    /// <summary>
    /// Updated metric ID. Only permitted for metric triggers.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// Updated metric threshold. Only permitted for metric triggers.
    /// </summary>
    [JsonPropertyName("metricThreshold")]
    public int? MetricThreshold { get; set; }

    /// <summary>
    /// Updated event attribute filters. Only permitted for metric triggers. Set to null to clear.
    /// </summary>
    [JsonPropertyName("eventAttributes")]
    public IEnumerable<PatchPointsTriggersRequestItemEventAttributesItem>? EventAttributes { get; set; }

    /// <summary>
    /// Updated achievement ID. Only permitted for achievement triggers.
    /// </summary>
    [JsonPropertyName("achievementId")]
    public string? AchievementId { get; set; }

    /// <summary>
    /// Updated streak length. Only permitted for streak triggers.
    /// </summary>
    [JsonPropertyName("streakLength")]
    public int? StreakLength { get; set; }

    /// <summary>
    /// Updated time unit. Only permitted for time triggers.
    /// </summary>
    [JsonPropertyName("timeUnit")]
    public PatchPointsTriggersRequestItemTimeUnit? TimeUnit { get; set; }

    /// <summary>
    /// Updated time interval. Only permitted for time triggers.
    /// </summary>
    [JsonPropertyName("timeInterval")]
    public int? TimeInterval { get; set; }

    /// <summary>
    /// Updated block-if-out-of-points setting.
    /// </summary>
    [JsonPropertyName("blockIfOutOfPoints")]
    public bool? BlockIfOutOfPoints { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
