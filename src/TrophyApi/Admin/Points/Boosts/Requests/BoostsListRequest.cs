using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin.Points;

[Serializable]
public record BoostsListRequest
{
    /// <summary>
    /// Maximum number of results to return (1-100, default 10).
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Number of results to skip for pagination (default 0).
    /// </summary>
    [JsonIgnore]
    public int? Skip { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
