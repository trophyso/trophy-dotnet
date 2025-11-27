using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record UsersLeaderboardRequest
{
    /// <summary>
    /// Specific run date in YYYY-MM-DD format. If not provided, returns the current run.
    /// </summary>
    [JsonIgnore]
    public string? Run { get; set; }

    /// <summary>
    /// The number of events to return in the history array.
    /// </summary>
    [JsonIgnore]
    public int? NumEvents { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
