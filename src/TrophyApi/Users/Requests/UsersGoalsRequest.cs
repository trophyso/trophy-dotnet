using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record UsersGoalsRequest
{
    /// <summary>
    /// When set, only return goals with this status. A goal's steps come with it, whatever their own status.
    /// </summary>
    [JsonIgnore]
    public GoalStatus? Status { get; set; }

    /// <summary>
    /// Number of goals to skip. Defaults to 0.
    /// </summary>
    [JsonIgnore]
    public int? Skip { get; set; }

    /// <summary>
    /// Maximum number of goals to return. Defaults to 100 and cannot exceed 100.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
