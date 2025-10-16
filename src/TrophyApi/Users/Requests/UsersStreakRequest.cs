using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record UsersStreakRequest
{
    /// <summary>
    /// The number of past streak periods to include in the streakHistory field of the  response.
    /// </summary>
    [JsonIgnore]
    public int? HistoryPeriods { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
