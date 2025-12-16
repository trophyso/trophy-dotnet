using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin;

[Serializable]
public record RestoreStreaksRequest
{
    /// <summary>
    /// Array of users to restore streaks for. Maximum 100 users per request.
    /// </summary>
    [JsonPropertyName("users")]
    public IEnumerable<RestoreStreaksRequestUsersItem> Users { get; set; } =
        new List<RestoreStreaksRequestUsersItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
