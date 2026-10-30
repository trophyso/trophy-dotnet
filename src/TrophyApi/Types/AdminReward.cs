using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A reward returned from the admin rewards endpoints.
/// </summary>
[Serializable]
public record AdminReward : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the reward.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The reward name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The reward key.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// The reward description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The reward status.
    /// </summary>
    [JsonPropertyName("status")]
    public required AdminRewardStatus Status { get; set; }

    /// <summary>
    /// The type of reward.
    /// </summary>
    [JsonPropertyName("type")]
    public required AdminRewardType Type { get; set; }

    /// <summary>
    /// The UUID of the points system. Only present for points rewards.
    /// </summary>
    [JsonPropertyName("pointsSystemId")]
    public string? PointsSystemId { get; set; }

    /// <summary>
    /// The number of points granted. Only present for points rewards.
    /// </summary>
    [JsonPropertyName("points")]
    public int? Points { get; set; }

    /// <summary>
    /// The maximum number of times a user can be awarded the reward. Null means unlimited.
    /// </summary>
    [JsonPropertyName("maxRedemptions")]
    public int? MaxRedemptions { get; set; }

    /// <summary>
    /// User attribute filters applied to the reward.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<AdminRewardUserAttributesItem> UserAttributes { get; set; } =
        new List<AdminRewardUserAttributesItem>();

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
