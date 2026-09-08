using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing deleted achievements represented by ID and any per-item issues, including invalid or missing achievement IDs.
/// </summary>
[Serializable]
public record DeleteAchievementsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of deleted achievements represented by ID.
    /// </summary>
    [JsonPropertyName("deleted")]
    public IEnumerable<DeletedResource> Deleted { get; set; } = new List<DeletedResource>();

    /// <summary>
    /// Array of issues encountered during achievement deletion.
    /// </summary>
    [JsonPropertyName("issues")]
    public IEnumerable<AdminIssue> Issues { get; set; } = new List<AdminIssue>();

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
