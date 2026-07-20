using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Details about the reactivation message.
/// </summary>
[Serializable]
public record WebhooksEmailsReactivationDuePayloadReactivation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reactivation message number in the sequence.
    /// </summary>
    [JsonPropertyName("messageNumber")]
    public required int MessageNumber { get; set; }

    /// <summary>
    /// The number of days since the user was last active.
    /// </summary>
    [JsonPropertyName("daysSinceLastActive")]
    public required int DaysSinceLastActive { get; set; }

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
