using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A reward to create. Optionally include triggers.
/// </summary>
[Serializable]
public record CreateRewardRequestItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reward name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The reward key. Only alphanumeric characters, hyphens, and underscores are permitted.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// A short description of the reward.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The status of the reward. Defaults to 'inactive'.
    /// </summary>
    [JsonPropertyName("status")]
    public CreateRewardRequestItemStatus? Status { get; set; }

    /// <summary>
    /// The type of reward. `points` rewards grant points when redeemed. `custom` rewards are fulfilled by your own system.
    /// </summary>
    [JsonPropertyName("type")]
    public required CreateRewardRequestItemType Type { get; set; }

    /// <summary>
    /// Required if type is `points`. The UUID of the points system to grant points in.
    /// </summary>
    [JsonPropertyName("pointsSystemId")]
    public string? PointsSystemId { get; set; }

    /// <summary>
    /// Required if type is `points`. The number of points to grant.
    /// </summary>
    [JsonPropertyName("points")]
    public int? Points { get; set; }

    /// <summary>
    /// The maximum number of times a user can be awarded the reward. Null means unlimited.
    /// </summary>
    [JsonPropertyName("maxRedemptions")]
    public int? MaxRedemptions { get; set; }

    /// <summary>
    /// Optional user attribute filters. Only users who match are awarded the reward.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<CreateRewardRequestItemUserAttributesItem>? UserAttributes { get; set; }

    /// <summary>
    /// Optional array of triggers to create alongside the reward.
    /// </summary>
    [JsonPropertyName("triggers")]
    public IEnumerable<CreateRewardTriggerRequestItem>? Triggers { get; set; }

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
