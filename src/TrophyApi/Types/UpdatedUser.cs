using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// An object with editable user fields.
/// </summary>
[Serializable]
public record UpdatedUser : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The user's email address. Required if subscribeToEmails is true.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The name to refer to the user by in emails.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The user's timezone (used for email scheduling).
    /// </summary>
    [JsonPropertyName("tz")]
    public string? Tz { get; set; }

    /// <summary>
    /// The user's device tokens, used for push notifications.
    /// </summary>
    [JsonPropertyName("deviceTokens")]
    public IEnumerable<string>? DeviceTokens { get; set; }

    /// <summary>
    /// Whether the user should receive Trophy-powered emails. If false, Trophy will not store the user's email address.
    /// </summary>
    [JsonPropertyName("subscribeToEmails")]
    public bool? SubscribeToEmails { get; set; }

    /// <summary>
    /// User attributes as key-value pairs. Keys must match existing user attributes set up in the Trophy dashboard.
    /// </summary>
    [JsonPropertyName("attributes")]
    public Dictionary<string, string>? Attributes { get; set; }

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
