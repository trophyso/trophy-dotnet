using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin.Streaks;

[Serializable]
public record PausesDeleteRequest
{
    /// <summary>
    /// Streak pause IDs to archive. Repeat the query param or provide a comma-separated list.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Ids { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
