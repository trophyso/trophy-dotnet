using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record StreaksRankingsRequest
{
    /// <summary>
    /// Number of users to return. Must be between 1 and 100.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Whether to rank users by active streaks or longest streaks ever achieved.
    /// </summary>
    [JsonIgnore]
    public StreaksRankingsRequestType? Type { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
