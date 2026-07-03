using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record WebhooksStreakExtendedPayload : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The webhook event type.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "streak.extended";

    /// <summary>
    /// The user who extended the streak.
    /// </summary>
    [JsonPropertyName("user")]
    public required User User { get; set; }

    /// <summary>
    /// The streak that was extended.
    /// </summary>
    [JsonPropertyName("streak")]
    public required BaseStreakResponse Streak { get; set; }

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
