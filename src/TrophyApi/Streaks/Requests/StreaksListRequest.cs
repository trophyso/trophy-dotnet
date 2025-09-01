using TrophyApi.Core;

namespace TrophyApi;

public record StreaksListRequest
{
    /// <summary>
    /// A list of up to 100 user IDs.
    /// </summary>
    public IEnumerable<string> UserIds { get; set; } = new List<string>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
