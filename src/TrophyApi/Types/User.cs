using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A user of your application.
/// </summary>
[Serializable]
public record User
{
    /// <summary>
    /// The ID of the user in your database. Must be a string.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The user's email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The name of the user.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The user's timezone.
    /// </summary>
    [JsonPropertyName("tz")]
    public string? Tz { get; set; }

    /// <summary>
    /// The user's device tokens.
    /// </summary>
    [JsonPropertyName("deviceTokens")]
    public IEnumerable<string>? DeviceTokens { get; set; }

    /// <summary>
    /// Whether the user is opted into receiving Trophy-powered emails.
    /// </summary>
    [JsonPropertyName("subscribeToEmails")]
    public required bool SubscribeToEmails { get; set; }

    /// <summary>
    /// User attributes as key-value pairs. Keys must match existing user attributes set up in the Trophy dashboard.
    /// </summary>
    [JsonPropertyName("attributes")]
    public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Whether the user is in the control group, meaning they do not receive emails or other communications from Trophy.
    /// </summary>
    [JsonPropertyName("control")]
    public required bool Control { get; set; }

    /// <summary>
    /// The date and time the user was created, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("created")]
    public required DateTime Created { get; set; }

    /// <summary>
    /// The date and time the user was last updated, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("updated")]
    public required DateTime Updated { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
