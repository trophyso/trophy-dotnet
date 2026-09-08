using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Replacement freeze configuration. `startCount` and `maxCount` are required. Auto-earn is a pair: both `autoEarnInterval` and `autoEarnAmount` must be set to enable auto-earn, or both omitted/`null` to disable it.
/// </summary>
[Serializable]
public record UpdateStreakSettingsFreezes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Number of freezes new users start with.
    /// </summary>
    [JsonPropertyName("startCount")]
    public required int StartCount { get; set; }

    /// <summary>
    /// Maximum number of freezes a user can have. Must be greater than or equal to `startCount`.
    /// </summary>
    [JsonPropertyName("maxCount")]
    public required int MaxCount { get; set; }

    /// <summary>
    /// Days between auto-earned freezes.
    /// </summary>
    [JsonPropertyName("autoEarnInterval")]
    public int? AutoEarnInterval { get; set; }

    /// <summary>
    /// Freezes earned per interval.
    /// </summary>
    [JsonPropertyName("autoEarnAmount")]
    public int? AutoEarnAmount { get; set; }

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
