using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record UpdateRewardTriggersRequestItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the trigger to update.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Updated trigger type. Can only be changed when the trigger is inactive. Required fields for the new type must be provided.
    /// </summary>
    [JsonPropertyName("type")]
    public UpdateRewardTriggersRequestItemType? Type { get; set; }

    /// <summary>
    /// Updated status.
    /// </summary>
    [JsonPropertyName("status")]
    public UpdateRewardTriggersRequestItemStatus? Status { get; set; }

    /// <summary>
    /// Updated user attribute filters. Set to null to clear.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<UpdateRewardTriggersRequestItemUserAttributesItem>? UserAttributes { get; set; }

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
    public IEnumerable<UpdateRewardTriggersRequestItemEventAttributesItem>? EventAttributes { get; set; }

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
    /// Updated leaderboard ID. Only permitted for leaderboard triggers.
    /// </summary>
    [JsonPropertyName("leaderboardId")]
    public string? LeaderboardId { get; set; }

    /// <summary>
    /// Updated rank. Only permitted for leaderboard triggers.
    /// </summary>
    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

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
