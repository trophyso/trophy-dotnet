using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin;

[Serializable]
public record MetricsListRequest
{
    /// <summary>
    /// Number of records to return.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Number of records to skip from the start of the list.
    /// </summary>
    [JsonIgnore]
    public int? Skip { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
