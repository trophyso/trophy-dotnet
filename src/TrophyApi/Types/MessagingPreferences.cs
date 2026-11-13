using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// The user's agentic messaging preferences: the channels its messages may use, and how many and what kinds of messages they want.
/// </summary>
[Serializable]
public record MessagingPreferences : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Channels agentic messages may use. An empty array turns agentic messages off for this user.
    /// </summary>
    [JsonPropertyName("channels")]
    public IEnumerable<NotificationChannel>? Channels { get; set; }

    /// <summary>
    /// How many and what kinds of agentic messages the user wants, from 1 (fewer: progress and celebrations only, at most one email and one push a week) to 5 (more).
    /// </summary>
    [JsonPropertyName("temperature")]
    public int? Temperature { get; set; }

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
