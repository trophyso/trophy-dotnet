using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record UpdatedUser
{
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
    /// Whether the user should receive Trophy-powered emails. Cannot be false if an email is provided.
    /// </summary>
    [JsonPropertyName("subscribeToEmails")]
    public bool? SubscribeToEmails { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
