using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing users whose streaks were reset and any issues encountered.
/// </summary>
[Serializable]
public record ResetStreaksResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of user IDs whose streaks were successfully reset to zero.
    /// </summary>
    [JsonPropertyName("resetUsers")]
    public IEnumerable<string> ResetUsers { get; set; } = new List<string>();

    /// <summary>
    /// Array of issues encountered during streak reset.
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
