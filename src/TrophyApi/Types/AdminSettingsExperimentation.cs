using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Experimentation settings.
/// </summary>
[Serializable]
public record AdminSettingsExperimentation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Percentage of new users assigned to the control group.
    /// </summary>
    [JsonPropertyName("controlRatio")]
    public required int ControlRatio { get; set; }

    /// <summary>
    /// Number of days after a user's first event used to measure retention and early engagement.
    /// </summary>
    [JsonPropertyName("userActivationWindow")]
    public required int UserActivationWindow { get; set; }

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
