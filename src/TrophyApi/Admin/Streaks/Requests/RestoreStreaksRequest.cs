using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin;

[Serializable]
public record RestoreStreaksRequest
{
    /// <summary>
    /// Array of user IDs to restore streaks for. Maximum 100 users per request.
    /// </summary>
    [JsonPropertyName("userIds")]
    public IEnumerable<string> UserIds { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
