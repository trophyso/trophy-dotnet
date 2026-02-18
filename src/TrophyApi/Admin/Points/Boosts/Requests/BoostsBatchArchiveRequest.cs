using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin.Points;

[Serializable]
public record BoostsBatchArchiveRequest
{
    /// <summary>
    /// A list of up to 100 boost IDs.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Ids { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
