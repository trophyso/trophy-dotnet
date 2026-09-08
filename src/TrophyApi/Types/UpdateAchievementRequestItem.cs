using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// An achievement update object. `id` is required; all other fields are optional. Omitted fields are preserved. Send `null` for `description`, `badge`, or `userAttributes` to clear them.
/// </summary>
[Serializable]
public record UpdateAchievementRequestItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the achievement to update.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The updated achievement name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The updated trigger type. Changing trigger requires the new trigger's mandatory fields.
    /// </summary>
    [JsonPropertyName("trigger")]
    public UpdateAchievementRequestItemTrigger? Trigger { get; set; }

    /// <summary>
    /// The updated description. Send `null` to clear.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The updated status.
    /// </summary>
    [JsonPropertyName("status")]
    public UpdateAchievementRequestItemStatus? Status { get; set; }

    /// <summary>
    /// The updated badge, or `null` to clear it.
    /// </summary>
    [JsonPropertyName("badge")]
    public UpdateAchievementRequestItemBadge? Badge { get; set; }

    /// <summary>
    /// Updated user attribute filters. Send `null` to clear. Each `attributeId` must be an active user attribute.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<UpdateAchievementRequestItemUserAttributesItem>? UserAttributes { get; set; }

    /// <summary>
    /// Updated key. Only permitted for API achievements.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// Updated metric ID. Only permitted for metric achievements.
    /// </summary>
    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    /// <summary>
    /// Updated metric threshold. Only permitted for metric achievements.
    /// </summary>
    [JsonPropertyName("metricValue")]
    public double? MetricValue { get; set; }

    /// <summary>
    /// Updated event attribute filters. Only permitted for metric achievements. Send `null` to clear. Each `attributeId` must be an active event attribute.
    /// </summary>
    [JsonPropertyName("eventAttributes")]
    public IEnumerable<UpdateAchievementRequestItemEventAttributesItem>? EventAttributes { get; set; }

    /// <summary>
    /// Updated streak length. Only permitted for streak achievements.
    /// </summary>
    [JsonPropertyName("streakLength")]
    public int? StreakLength { get; set; }

    /// <summary>
    /// Updated anniversary years. Only permitted for anniversary achievements.
    /// </summary>
    [JsonPropertyName("anniversaryYears")]
    public int? AnniversaryYears { get; set; }

    /// <summary>
    /// Updated prerequisite achievement UUIDs. Only permitted for achievement achievements.
    /// </summary>
    [JsonPropertyName("achievementIds")]
    public IEnumerable<string>? AchievementIds { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
