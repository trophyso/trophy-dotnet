using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// The organization's branding, experimentation, and aggregation settings.
/// </summary>
[Serializable]
public record AdminSettings : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("branding")]
    public required AdminSettingsBranding Branding { get; set; }

    [JsonPropertyName("experimentation")]
    public required AdminSettingsExperimentation Experimentation { get; set; }

    [JsonPropertyName("aggregationPeriod")]
    public required AdminAggregationPeriod AggregationPeriod { get; set; }

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
