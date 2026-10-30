using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A reward update object. Only id is required; all other fields are optional. Triggers are updated through the reward triggers endpoints.
/// </summary>
[Serializable]
public record UpdateRewardRequestItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the reward to update.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Updated name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Updated description. Set to null to clear.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Updated status.
    /// </summary>
    [JsonPropertyName("status")]
    public UpdateRewardRequestItemStatus? Status { get; set; }

    /// <summary>
    /// Updated type. Changing to `points` requires pointsSystemId and points if the reward has none.
    /// </summary>
    [JsonPropertyName("type")]
    public UpdateRewardRequestItemType? Type { get; set; }

    /// <summary>
    /// Updated points system ID. Only permitted for points rewards.
    /// </summary>
    [JsonPropertyName("pointsSystemId")]
    public string? PointsSystemId { get; set; }

    /// <summary>
    /// Updated number of points. Only permitted for points rewards.
    /// </summary>
    [JsonPropertyName("points")]
    public int? Points { get; set; }

    /// <summary>
    /// Updated maximum awards per user. Set to null for unlimited.
    /// </summary>
    [JsonPropertyName("maxRedemptions")]
    public int? MaxRedemptions { get; set; }

    /// <summary>
    /// Updated user attribute filters. Set to null to clear.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<UpdateRewardRequestItemUserAttributesItem>? UserAttributes { get; set; }

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
