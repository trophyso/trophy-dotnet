using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record UsersPointsRequest
{
    /// <summary>
    /// The number of recent point awards to return.
    /// </summary>
    [JsonIgnore]
    public int? Awards { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
