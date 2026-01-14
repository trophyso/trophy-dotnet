using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record UpdateUserPreferencesRequest
{
    [JsonPropertyName("notifications")]
    public NotificationPreferences? Notifications { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
