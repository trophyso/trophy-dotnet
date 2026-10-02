using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin;

[Serializable]
public record ResetStreaksRequest
{
    /// <summary>
    /// Array of users to reset streaks for. Maximum 100 users per request.
    /// </summary>
    [JsonPropertyName("users")]
    public IEnumerable<ResetStreaksRequestUsersItem> Users { get; set; } =
        new List<ResetStreaksRequestUsersItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
