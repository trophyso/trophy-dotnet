using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A points system returned from the admin points systems endpoints.
/// </summary>
[Serializable]
public record AdminPointsSystem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the points system.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The points system name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The points system key.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// The points system description.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// The points system status.
    /// </summary>
    [JsonPropertyName("status")]
    public required AdminPointsSystemStatus Status { get; set; }

    /// <summary>
    /// The badge for the points system.
    /// </summary>
    [JsonPropertyName("badge")]
    public AdminPointsSystemBadge? Badge { get; set; }

    /// <summary>
    /// The maximum points a user can earn.
    /// </summary>
    [JsonPropertyName("maxPoints")]
    public int? MaxPoints { get; set; }

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
