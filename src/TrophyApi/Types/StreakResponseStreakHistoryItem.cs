using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// An object representing a past streak period.
/// </summary>
[Serializable]
public record StreakResponseStreakHistoryItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The date this streak period started.
    /// </summary>
    [JsonPropertyName("periodStart")]
    public required string PeriodStart { get; set; }

    /// <summary>
    /// The date this streak period ended.
    /// </summary>
    [JsonPropertyName("periodEnd")]
    public required string PeriodEnd { get; set; }

    /// <summary>
    /// The length of the user's streak during this period.
    /// </summary>
    [JsonPropertyName("length")]
    public required int Length { get; set; }

    /// <summary>
    /// Whether the user used a streak freeze during this period. Only present if the organization has enabled streak freezes.
    /// </summary>
    [JsonPropertyName("usedFreeze")]
    public bool? UsedFreeze { get; set; }

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
