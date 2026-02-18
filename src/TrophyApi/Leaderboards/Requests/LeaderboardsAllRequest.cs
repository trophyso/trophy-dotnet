using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record LeaderboardsAllRequest
{
    /// <summary>
    /// When set to 'true', leaderboards with status 'finished' will be included in the response. By default, finished leaderboards are excluded.
    /// </summary>
    [JsonIgnore]
    public bool? IncludeFinished { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
