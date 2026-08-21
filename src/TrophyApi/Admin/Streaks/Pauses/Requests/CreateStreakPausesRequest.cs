using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin.Streaks;

[Serializable]
public record CreateStreakPausesRequest
{
    /// <summary>
    /// Array of pauses to create. Maximum 100 pauses per request.
    /// </summary>
    [JsonPropertyName("pauses")]
    public IEnumerable<CreateStreakPausesRequestPausesItem> Pauses { get; set; } =
        new List<CreateStreakPausesRequestPausesItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
