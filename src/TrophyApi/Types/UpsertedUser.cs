using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record UpsertedUser
{
    /// <summary>
    /// The ID of the user in your database. Must be a string.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
