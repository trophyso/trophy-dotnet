using TrophyApi.Core;

namespace TrophyApi;

public record UsersAchievementsRequest
{
    /// <summary>
    /// When set to 'true', returns both completed and incomplete achievements for the user. When omitted or set to any other value, returns only completed achievements.
    /// </summary>
    public string? IncludeIncomplete { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
