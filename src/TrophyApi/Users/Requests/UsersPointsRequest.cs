using TrophyApi.Core;

namespace TrophyApi;

public record UsersPointsRequest
{
    /// <summary>
    /// The number of recent point awards to return.
    /// </summary>
    public int? Awards { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
