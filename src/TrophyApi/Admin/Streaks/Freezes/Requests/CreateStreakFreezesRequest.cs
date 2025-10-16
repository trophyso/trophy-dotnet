using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin.Streaks;

[Serializable]
public record CreateStreakFreezesRequest
{
    /// <summary>
    /// Array of freezes to create. Maximum 1,000 freezes per request.
    /// </summary>
    [JsonPropertyName("freezes")]
    public IEnumerable<CreateStreakFreezesRequestFreezesItem> Freezes { get; set; } =
        new List<CreateStreakFreezesRequestFreezesItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
