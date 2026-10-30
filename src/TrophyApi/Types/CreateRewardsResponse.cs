using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing created rewards and any per-item issues.
/// </summary>
[Serializable]
public record CreateRewardsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of successfully created rewards.
    /// </summary>
    [JsonPropertyName("created")]
    public IEnumerable<CreatedAdminReward> Created { get; set; } = new List<CreatedAdminReward>();

    /// <summary>
    /// Array of issues encountered during creation.
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
