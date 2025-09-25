using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record CreateStreakFreezesResponse
{
    /// <summary>
    /// Array of issues encountered during freeze creation.
    /// </summary>
    [JsonPropertyName("issues")]
    public IEnumerable<BulkInsertIssue> Issues { get; set; } = new List<BulkInsertIssue>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
