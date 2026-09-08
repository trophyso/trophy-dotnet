using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Organization streak freeze configuration. `null` on the parent object means freezes are disabled.
/// </summary>
[Serializable]
public record StreakSettingsFreezes : IJsonOnDeserialized
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
    /// Maximum number of freezes a user can have.
    /// </summary>
    [JsonPropertyName("maxCount")]
    public required int MaxCount { get; set; }

    /// <summary>
    /// Days between auto-earned freezes. `null` when auto-earn is off.
    /// </summary>
    [JsonPropertyName("autoEarnInterval")]
    public int? AutoEarnInterval { get; set; }

    /// <summary>
    /// Freezes earned per interval. `null` when auto-earn is off.
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
