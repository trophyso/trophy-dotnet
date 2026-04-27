using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin.Points;

[Serializable]
public record TriggersDeleteRequest
{
    /// <summary>
    /// Trigger IDs to delete. Can be repeated or comma-separated.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Ids { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
