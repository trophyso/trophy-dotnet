using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record StreaksListRequest
{
    /// <summary>
    /// A list of up to 100 user IDs.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> UserIds { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
