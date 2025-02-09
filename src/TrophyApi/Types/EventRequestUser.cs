using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record EventRequestUser
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
    /// The name to refer to the user by in emails.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The user's timezone (used for email scheduling).
    /// </summary>
    [JsonPropertyName("tz")]
    public string? Tz { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
